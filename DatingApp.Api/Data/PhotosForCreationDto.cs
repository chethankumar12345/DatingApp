using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DatingApp.Api.Data
{
    public class PhotosForCreationDto
    {
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

        public PhotosForCreationDto()
        {
            DateAdded = DateTime.Now;
            ;
        }
    }
}
