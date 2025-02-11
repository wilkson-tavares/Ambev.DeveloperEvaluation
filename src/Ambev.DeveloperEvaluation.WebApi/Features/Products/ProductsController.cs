using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.ListCategories;
using Ambev.DeveloperEvaluation.Application.Products.ListProducts;
using Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UpdateProductResponse = Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct.UpdateProductResponse;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

/// <summary>
/// Controller for managing product operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ProductsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Creates a new product
    /// </summary>
    /// <param name="request">The product creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        
        return Created("GetProduct", new { id = response.Id }, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateProductResponse>(response)
        });
    }
    
    /// <summary>
    /// Retrieves a product by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetProductRequest() { Id = id };
        var validator = new GetProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetProductCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<GetProductResponse>(response));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<ListProductsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListProducts([FromQuery] ListProductsRequest request, CancellationToken cancellationToken)
    {
        var validator = new ListProductsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<ListProductsCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        
        var paginatedList = new PaginatedList<ListProductsResponse>(
            items: _mapper.Map<List<ListProductsResponse>>(response.Data),
            count: response.CurrentPage,
            pageNumber: response.TotalItems,
            pageSize: response.TotalPages
        );
        
        return OkPaginated(paginatedList);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        
        var validator = new UpdateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var command = _mapper.Map<UpdateProductCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        
        return Ok(_mapper.Map<UpdateProductResponse>(result));
    }
    
    /// <summary>
    /// Deletes a product by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the product was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteProductRequest() { Id = id };
        var validator = new DeleteProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteProductCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Product deleted successfully"
        });
    }
    
    [HttpGet("categories")]
    [ProducesResponseType(typeof(ApiResponseWithData<List<string>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListCategories(CancellationToken cancellationToken)
    {
        var command = new ListCategoriesCommand();
        var response = await _mediator.Send(command, cancellationToken);

        if (!response.Categories.Any())
            return NotFound("Categories not found");
        
        return Ok(new ApiResponseWithData<List<string>>
        {
            Success = true,
            Message = "Categories retrieved successfully",
            Data = response.Categories
        });
    }
    
    [HttpGet("by-category")]
    [ProducesResponseType(typeof(PaginatedResponse<ListProductsByCategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListProductsByCategory([FromQuery] ListProductsByCategoryRequest request, CancellationToken cancellationToken)
    {
        var validator = new ListProductsByCategoryRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<ListProductsByCategoryCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        var paginatedList = new PaginatedList<ListProductsByCategoryResponse>(
            items: _mapper.Map<List<ListProductsByCategoryResponse>>(response.Data),
            count: request.Page,
            pageNumber: response.TotalItems,
            pageSize: response.TotalPages
        );

        return OkPaginated(paginatedList);
    }
}