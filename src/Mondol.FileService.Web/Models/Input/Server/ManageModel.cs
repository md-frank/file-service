// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Mondol.FileService.Web.Models.Input.User
{
    public class SyncFileModel
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileToken { get; set; }
    }
}
