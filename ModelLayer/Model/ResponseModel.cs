﻿using ModelLayer.Model;

namespace WebAPI.Controllers
{
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    /// <summary>
    /// Generic response model for API responses.
    /// </summary>
    /// <typeparam name="T">Type of data being returned in the response.</typeparam>
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> feature-addressbook-controller
=======
>>>>>>> feature-addressbook-dto
=======
>>>>>>> feature-addressbook-service
=======
>>>>>>> feature-authentication
=======
>>>>>>> feature-password-reset
=======
>>>>>>> feature-redis-cache
=======
>>>>>>> feature-rabbitmq-events
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<AddressBookEntry> Data { get; set; }
    }
}