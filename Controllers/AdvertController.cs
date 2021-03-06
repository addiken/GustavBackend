﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gustav_v2.db_context;
using gustav_v2.entity;
using gustav_v2.request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gustav_v2.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly ILogger<Advert> _logger;

        public AdvertController(ILogger<Advert> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/GetAllAdverts")]
        public IEnumerable<Advert> Get()
        {
            using (AdvertContext db = new AdvertContext())
            {
                return db.Advert.ToList();
            }
        }
        [HttpGet]
        [Route("api/GetUserAdverts")]
        public IEnumerable<Advert> GetU(long phone)
        {
            List<Advert> adverts;
            List<Advert> radverts = new List<Advert>();
            using (AdvertContext db = new AdvertContext())
            {
                adverts = db.Advert.ToList();
            }
            foreach (var advert in adverts)
            {
                if (advert.OwnerPhone == phone)
                {
                    radverts.Add(advert);
                }
            }
            return radverts;
        }
        [HttpGet]
        [Route("api/GetAdvert")]
        public Advert Get(int id)
        {
            using (AdvertContext db = new AdvertContext())
            {
                return db.Advert.Find(id);
            }
        }
        [HttpPost]
        [Route("api/CreateAdvert")]
        public void CreateAdvert(CreateAdvertRequest request)
        {
            ValidateUser(request.Phone, request.Password);
            Advert advert = new Advert
            {
                District = request.District,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                Area = request.Area,
                Floor = request.Floor,
                Rooms = request.Rooms,
                Description = request.Description,
                Price = request.Price,
                OwnerName = request.OwnerName,
                OwnerPhone = request.OwnerPhone
            };
            using (AdvertContext db = new AdvertContext())
            {
                db.Advert.Add(advert);
                db.SaveChanges();
            }
        }
        
        [HttpPost]
        [Route("api/EditAdvert")]
        public void EditTask(EditAdvertRequest request)
        {
            ValidateUser(request.Phone, request.Password);
            Advert advert = new Advert
            {
                Id = request.Id,
                District = request.District,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                Area = request.Area,
                Floor = request.Floor,
                Rooms = request.Rooms,
                Description = request.Description,
                Price = request.Price,
                OwnerName = request.OwnerName,
                OwnerPhone = request.OwnerPhone
            };
            using (AdvertContext db = new AdvertContext())
            {
                db.Advert.Update(advert);
                db.SaveChanges();
            }
        }
        
        [HttpDelete]
        [Route("api/DeleteAdvert")]
        public void DeleteAdvert(int id, string phone, string password)
        {
            ValidateUser(phone, password);
            using (AdvertContext db = new AdvertContext())
            {
                Advert advert = db.Advert.Find(id);
                if (advert != null){ db.Advert.Remove(advert); }
                db.SaveChanges();
            }
        }

        private void ValidateUser(string phone, string password)
        {
            List<User> users;
            using (AdvertContext db = new AdvertContext())
            {
                users = db.Users.ToList();
            }
            int i = 0;
            foreach (var u in users)
            {
                if (phone.Equals(u.Phone) && password.Equals(u.Password))
                {
                    i++;
                } 
            }
            if(i != 1){throw new UnauthorizedAccessException();}
        }
    }
}