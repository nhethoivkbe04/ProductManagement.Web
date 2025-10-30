using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Web.DTOs;
using ProductManagement.Web.Services.Interfaces;

namespace ProductManagement.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // ================================
        // GET: /Products (Danh sách sản phẩm)
        // ================================
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        // ================================
        // GET: /Products/Details/5
        // ================================
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // ================================
        // GET: /Products/Create
        // ================================
        public IActionResult Create()
        {
            return View();
        }

        // ================================
        // POST: /Products/Create
        // ================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
                return View(productDto);

            await _productService.CreateProductAsync(productDto);
            return RedirectToAction(nameof(Index));
        }

        // ================================
        // GET: /Products/Edit/5
        // ================================
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            var productDto = _mapper.Map<ProductUpdateDto>(product);
            return View(productDto);
        }

        // ================================
        // POST: /Products/Edit/5
        // ================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductUpdateDto productDto)
        {
            if (id != productDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(productDto);

            var result = await _productService.UpdateProductAsync(productDto);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // ================================
        // GET: /Products/Delete/5
        // ================================
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            // Map sang DTO để hiển thị trong View Delete
            var dto = _mapper.Map<ProductDeleteDto>(product);
            return View(dto);
        }

        // ================================
        // POST: /Products/Delete/5 (xác nhận xóa)
        // ================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
