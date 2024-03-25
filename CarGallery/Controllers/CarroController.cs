using CarGallery.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarGallery.Controllers
{
    public class CarroController : Controller
    {
        private readonly CarGalleryContext _context;

        public CarroController(CarGalleryContext context)
        {
            _context = context;
        }


        public IActionResult Create()
        {
            var fabricantes = _context.Fabricantes.ToList();

            ViewBag.fabricantes = fabricantes;

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Carro carro, [Bind("idFabricante")] int idFabricante)
        {
            var fabricante = this._context.Fabricantes.FirstOrDefault(x => x.Id == idFabricante);

            if (fabricante == null)
                throw new Exception("Fabricante não encontrado");
            

             var image = Request.Form.Files.GetFile("imageFile");

                 if(image != null && image.ContentType.StartsWith("image/") == false )
                 {
                     ModelState.AddModelError("image_error", "Extensão de arquivo não permitida");
                     var fabricantes = _context.Fabricantes.ToList();
                     ViewBag.fabricantes = fabricantes;
                     return View();
                 }

                 var fileName = image.FileName;
                 var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens_carro", image.FileName); 

                 using (System.IO.Stream stream = new FileStream(path, FileMode.Create)) 
                 {
                     image.CopyTo(stream);
                     stream.Flush();
                 }
                 carro.Imagem = $"/imagens_carro/{image.FileName}"; 


            fabricante.Carros.Add(carro);

            this._context.Fabricantes.Update(fabricante);
            this._context.SaveChanges();

            return Redirect("/fabricante");
           
        }

        public IActionResult Detail(int id)
        {
            var carro = _context.Carros.FirstOrDefault(c => c.Id == id);

            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }
    }
}