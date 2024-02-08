﻿using Billing.Data;
using Billing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace Billing.Controllers
{
    public class BillsController(ApplicationDbContext db) : Controller
    {
		private readonly ApplicationDbContext _db = db;
		public IActionResult Index()
		{
			List<Invoice> objInvoiceList = _db.Invoices.Include(u => u.Customer).ToList();
			return View(objInvoiceList);
		}
		public IActionResult Details(long? id)
		{
			if (id == null || id == 0)
			{
				TempData["FailureMessage"] = "Invoice Not Found";
				return View();
			}
			// Retrieve all InvoiceProducts where InvoiceId matches the provided invoiceid
			List<InvoiceProduct>? objInvoiceProductList = _db.InvoiceProducts
				.Where(i => i.InvoiceId == id)
				.Include(p => p.Product)
				.ToList();

			if (objInvoiceProductList == null)
			{
				TempData["FailureMessage"] = "This Invoice has no Products";
				return View();
			}
			return View(objInvoiceProductList);
		}

	}
}
