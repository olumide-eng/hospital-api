﻿using System.ComponentModel.DataAnnotations;

namespace Hospital_Api.Models.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required]

        public string[] Roles { get; set; }

    }
}
