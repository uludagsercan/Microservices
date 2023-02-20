namespace FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Queries.GetBasket
{
    public class GetBasketQueryResponse
    {
       

  
    }
    public class SuccessBasketResult : GetBasketQueryResponse
    {
        public Domain.Entities.Basket Basket { get; set; }
        public int StatusCode { get; set; }
    }

    public class ErrorBasketResult : GetBasketQueryResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }


}
