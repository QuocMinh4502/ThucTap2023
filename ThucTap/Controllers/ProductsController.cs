using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Commands;
using ThucTap.Models;
using ThucTap.Queries;
using static ThucTap.Commands.CreateCommands;
using static ThucTap.Commands.DeleteCommands;
using static ThucTap.Commands.UpdateCommands;
using static ThucTap.Queries.GetByIdQuery;
using static ThucTap.Queries.GetListQuery;

namespace ThucTap.Controllers
{
    // ProductsController
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductDetails>> GetProductListAsync()
        {
            var productDetails = await mediator.Send(new GetProductListQuery());
            return productDetails;
        }

        [HttpGet("{productId}")]
        public async Task<ProductDetails> GetProductByIdAsync(int productId)
        {
            var productDetails = await mediator.Send(new GetProductByIdQuery() { Id = productId });
            return productDetails;
        }

        [HttpPost]
        public async Task<ProductDetails> AddProductAsync(ProductDetails productDetails)
        {
            var productDetail = await mediator.Send(new CreateProductCommand(
                productDetails.Name,
                productDetails.Description,
                productDetails.Price,
                productDetails.Category));
            return productDetail;
        }

        [HttpPut]
        public async Task<int> UpdateProductAsync(ProductDetails productDetails)
        {
            var isProductDetailUpdated = await mediator.Send(new UpdateProductCommand(
               productDetails.Id,
               productDetails.Name,
               productDetails.Description,
               productDetails.Price,
               productDetails.Category));
            return isProductDetailUpdated;
        }

        [HttpDelete("{productId}")]
        public async Task<int> DeleteProductAsync(int productId)
        {
            return await mediator.Send(new DeleteProductCommand() { Id = productId });
        }
    }

}