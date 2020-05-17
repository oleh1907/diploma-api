using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DiplomaBLL.Analysis;
using DiplomaBLL.FileSave;
using DiplomaDBL;
using DiplomaEntities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly DiplomaDbContext context;
        private readonly IFileService fileService;
        private readonly IAnalysisService analysisService;

        public AnalysisController(DiplomaDbContext context, IFileService fileService, IAnalysisService analysisService)
        {
            this.context = context;
            this.fileService = fileService;
            this.analysisService = analysisService;
        }

        [HttpPost]
        public async Task<IActionResult> Analyze([FromForm]IFormFile image)
        {
            try
            {
                string extension = Path.GetExtension(image.FileName);

                //if(!(new[] { "png", "jpeg" }).Contains(extension))
                //    return BadRequest("Недопустимий формат зображення");

                string path = await fileService.SaveOnDriveAsync(image);

                var foodName = await analysisService.AnalyseImage(path);

                if (foodName == null)
                    return BadRequest("Подібний тип продуктів харчування відсутній в базі");


                var dbFoodInfo = context.FoodInfos.FirstOrDefault(f => f.OfficialName == foodName);

                string category = context.Categories.FirstOrDefault(c => c.Id == dbFoodInfo.CategoryId).Name;
                string quality = context.Qualitys.FirstOrDefault(q => q.Id == dbFoodInfo.QualityId).Name;

                return Ok(new
                {
                    NameToDisplay = dbFoodInfo.NameToDisplay,
                    Description = dbFoodInfo.Description,
                    Category = category,
                    Quality = quality
                });
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}