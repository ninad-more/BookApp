using MediatR;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using BookApp.Queries;
using BookApp.Services.Interfaces;

namespace BookApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBookService _service;

        public BookController(IMediator mediator, IBookService service)
        {
            _mediator = mediator;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View(await _mediator.Send(new GetBookListQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            return View(await _mediator.Send(new GetBookByIdQuery(Id)));
        }

        [HttpGet]
        public async Task<IActionResult> Add() => View();

        [HttpGet]
        public async Task<IActionResult> Update(int Id) => View(await _mediator.Send(new GetBookByIdQuery(Id)));

        [HttpGet]
        public async Task<IActionResult> Delete(int Id) => View(await _mediator.Send(new GetBookByIdQuery(Id)));

        [HttpPost]
        public async Task<IActionResult> Add(BookViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(new AddBookQuery(model));
                }

                return RedirectToAction(nameof(GetAll));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Update(model);

                if (result)
                {
                    ViewBag.Message = "Data updated successfully";
                }
            }

            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BookViewModel model)
        {
            var result = await _service.Delete(model.Id);

            if (result)
            {
                return RedirectToAction(nameof(GetAll));
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}
