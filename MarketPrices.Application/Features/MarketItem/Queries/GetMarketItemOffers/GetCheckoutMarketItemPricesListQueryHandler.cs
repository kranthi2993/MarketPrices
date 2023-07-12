using AutoMapper;
using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems;
using MarketPrices.Domain;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketPrices.Application.Features.MarketItem.Queries.GetMarketItemOffers
{
    public class GetCheckoutMarketItemPricesListQueryHandler : IRequestHandler<GetCheckoutMarketItemPricesListQuery, List<CheckoutMarketItemListDto>>
    {
        private readonly IMarketItemOfferRepository _marketItemOfferRepository;
        private readonly IMarketItemQuantityRepository _marketItemQuantityRepository;
        private readonly IMapper _mapper;
        public GetCheckoutMarketItemPricesListQueryHandler(
            IMarketItemOfferRepository marketItemOfferRepository,
            IMarketItemQuantityRepository marketItemQuantityRepository,
            IMapper mapper)
        {
            _marketItemOfferRepository = marketItemOfferRepository;
            _marketItemQuantityRepository = marketItemQuantityRepository;
            _mapper = mapper;
        }
        public async Task<List<CheckoutMarketItemListDto>> Handle(GetCheckoutMarketItemPricesListQuery request, CancellationToken cancellationToken)
        {
            var items = await _marketItemQuantityRepository.GetMarketItemQuantityDetails(request.guid);
            var marketItemOffers = await _marketItemOfferRepository.GetMarketItemOfferWithDetails();

            var marketItemsDTO = _mapper.Map<List<MarketItemListDto>>(items);

            marketItemsDTO = marketItemsDTO.Where(x => x.Quantity > 0).Select(x => x).ToList();
            var marketItemsCheckoutList = await Task.Run(() => CalculateOffer(marketItemsDTO, marketItemOffers)).ConfigureAwait(false);
            return marketItemsCheckoutList;
        }

        private List<CheckoutMarketItemListDto> CalculateOffer(List<MarketItemListDto> items, List<MarketItemOffer> marketItemOffers)
        {

            var lstCheckoutMarketItemListDto = new List<CheckoutMarketItemListDto>();
            //Initial Copy to Object will all marketItems
            lstCheckoutMarketItemListDto.AddRange(items.Select(x => new CheckoutMarketItemListDto { Id = x.Id, Name = x.Name, Quantity = x.Quantity, Price = x.Price, ProductCode = x.ProductCode }));

            //Market items which has offers- Customer purchased Quantity is >= to OfferProvidedQunatity then filter the offers applicable for customer/apply discount
            var filterOffterAppliedItems = (from filteredMarketItemOffer in marketItemOffers
                                            join item in items
                                            on filteredMarketItemOffer.PurchasedMarketItemId equals item.Id
                                            where item.Quantity >= filteredMarketItemOffer.PurchasedQuantity
                                            select new
                                            {
                                                itemID = item.Id,
                                                filteredMarketItemOffer = filteredMarketItemOffer
                                            }).ToList();

           
            // Update Offername to Cart Items whose offer applies
            (from nc in lstCheckoutMarketItemListDto
            join c in filterOffterAppliedItems on nc.Id equals c.itemID
            select new { left = nc, right = c }).Select(Res =>
            {
                Res.left.OfferName = Res.right.filteredMarketItemOffer.Offer?.Name; 
                return Res.left;
            }).ToList();


            var lstOfferedMarketItemWithDifferentProducts = new List<CheckoutMarketItemListDto>();

            //Loop through Offers provided
            foreach (var a in filterOffterAppliedItems)
            {

                //if OfferId and MarketId products are same and if that exists update the marketid with quantity and price
                // Quantity - if offer purchased and Offered Quantity are different then CartQuantity *Offered  else Offered
                // Price - If Offered price has some value then OfferedPrice * CartQuantity else CartQuantity * CartPrice
                (from item in lstCheckoutMarketItemListDto
                 where item.Id == a.itemID && item.Id == a.filteredMarketItemOffer.OfferedMarketItemId
                 select item).ToList().ForEach(item =>
                 {
                     item.DiscountPrice = a.filteredMarketItemOffer.DiscountPrice * item.Quantity;
                     item.Quantity = a.filteredMarketItemOffer.OfferedQuantity != a.filteredMarketItemOffer.PurchasedQuantity ?
                                      item.Quantity * a.filteredMarketItemOffer.OfferedQuantity : item.Quantity;
                     item.Price = a.filteredMarketItemOffer.OfferedPrice != 0 ? a.filteredMarketItemOffer.OfferedPrice * item.Quantity : item.Price * item.Quantity;
                     item.OfferName = a.filteredMarketItemOffer.Offer?.Name;
                 });

                // if marketId and offerid product are not same then list the offer objects
                var listItem = (from item in items
                                where item.Id == a.itemID && item.Id != a.filteredMarketItemOffer.OfferedMarketItemId
                                select new CheckoutMarketItemListDto
                                {
                                    Id = a.filteredMarketItemOffer.OfferedMarketItemId,
                                    DiscountPrice = a.filteredMarketItemOffer.DiscountPrice,
                                    Quantity = a.filteredMarketItemOffer.OfferedQuantity,
                                    Price = a.filteredMarketItemOffer.OfferedPrice,
                                    Name = item.Name,
                                    OfferName = a.filteredMarketItemOffer.Offer?.Name,
                                    ProductCode = item.ProductCode
                                }).ToList();



                lstOfferedMarketItemWithDifferentProducts.AddRange(listItem);
            }

            //if offer object exist without any discount then update offering with Quantity and price
            var data = (from item in lstCheckoutMarketItemListDto
                        join offereditem in lstOfferedMarketItemWithDifferentProducts
                        on item.Id equals offereditem.Id
                        where item.DiscountPrice == 0 && item.OfferName == String.Empty
                        select new { item, offereditem }).Select(res =>
                        {
                            res.item.Price = (res.item.Price - res.offereditem.DiscountPrice) * res.item.Quantity;
                            res.item.Quantity = res.item.Quantity;
                            res.item.DiscountPrice = res.offereditem.DiscountPrice * res.item.Quantity;
                            res.item.OfferName = res.offereditem.OfferName;
                            return res.item;
                        }).ToList();

            //if offer object exist without any discount then insert offering which doesnot exist
            var insertItem = (from offereditem in lstOfferedMarketItemWithDifferentProducts
                              where !lstCheckoutMarketItemListDto.Any(x => x.Id == offereditem.Id)
                              select offereditem).ToList();


            foreach (var i in insertItem)
            {
                lstCheckoutMarketItemListDto.AddRange(new List<CheckoutMarketItemListDto>() {
                new CheckoutMarketItemListDto
                {
                    Id = i.Id,
                    DiscountPrice = i.DiscountPrice,
                    Quantity = i.Quantity,
                    Price = i.Price * i.Quantity,
                    Name = i.Name,
                    OfferName = i.OfferName,
                    ProductCode = i.ProductCode
                }});
            }

            //Calculate Price for non offer Items
            lstCheckoutMarketItemListDto.Where(x =>x.OfferName == string.Empty).Select(x => x.Price = x.Price *x.Quantity).ToList();

            return lstCheckoutMarketItemListDto;
        }
    }
}
