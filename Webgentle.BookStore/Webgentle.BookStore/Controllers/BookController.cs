﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController( BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data);

        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await (_bookRepository.GetBookbyId(id));
            return View(data);
        }

        public List<BookModel> Searchbook(string bookname, string authorname)
        {
            return _bookRepository.SearchBook(bookname, authorname);
        }

        public ViewResult AddNewBook(bool isSuccess = false , int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            int id =  await _bookRepository.AddNewBook(bookModel);
            if (id >0)
            {
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true , bookId = id});
            };
            return View();
        }
    }

}
