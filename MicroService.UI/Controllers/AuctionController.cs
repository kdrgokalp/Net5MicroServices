using MicroService.UI.Clients;
using MicroService.UI.Core.Repositories;
using MicroService.UI.Core.ResultModels;
using MicroService.UI.ViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroService.UI.Controllers
{
    
    public class AuctionController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ProductClient _productClient;
        private readonly AuctionClient _auctionClient;
        private readonly BidClient _bidClient;

        public AuctionController(IUserRepository userRepository, ProductClient productClient, AuctionClient auctionClient, BidClient bidClient)
        {
            _userRepository = userRepository;
            _productClient = productClient;
            _auctionClient = auctionClient;
            _bidClient = bidClient;
        }
        public async Task<IActionResult> Index()
        {
            var auctionList = await _auctionClient.GetAuctions();
            if (auctionList.IsSuccess)
                return View(auctionList.Data);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //Product GetAll
            var productList = await _productClient.GetProducts();
            if (productList.IsSuccess)
                ViewBag.ProductList = productList.Data;
            var userList = await _userRepository.GetAllAsync();
            ViewBag.UserList = userList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuctionViewModel model)
        {
            model.Status = default(int);
            model.CreatedAt = DateTime.Now;
            var createAuction = await _auctionClient.CreateAuction(model);
            if (createAuction.IsSuccess)
                return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> Detail(string id)
        {
            AuctionBidsViewModel model = new AuctionBidsViewModel();

            var auctionResponse = await _auctionClient.GetAuctionById(id);
            var bidsResponsee = await _bidClient.GetAllBidsByAuctionById(id);

            model.SellerUserName = HttpContext.User?.Identity.Name;
            model.AuctionId = auctionResponse.Data.Id;
            model.ProductId = auctionResponse.Data.ProductId;
            model.Bids = bidsResponsee.Data;
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            model.IsAdmin = Convert.ToBoolean(isAdmin);

            return View(model);
        }

        [HttpPost]
        public async Task<Result<string>> SendBid(BidsViewModel model)
        {
            model.CreateAt = DateTime.Now;
            var sendBidResponse = await _bidClient.SendBid(model);
            return sendBidResponse;
        }

        [HttpPost]
        public async Task<Result<string>> CompleteBid(string id)
        {
            var completeBidResponse = await _auctionClient.CompleteBid(id);
            return completeBidResponse;
        }
    }
}
