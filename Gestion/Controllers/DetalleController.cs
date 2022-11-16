using Microsoft.AspNetCore.Mvc;

using Gestion.Datos;
using Gestion.Models;

namespace Gestion.Controllers
{
    public class DetalleController : Controller
    {
        DetalleDatos _detalleDatos = new DetalleDatos();

        public IActionResult Listar(int idFactura)
        {
            //La vista mostrará una lista  de Detalle de la Factura actual 
            var oLista = _detalleDatos.Listar(idFactura);

            return View(oLista);
        }

      
        public IActionResult Guardar()
        {
            //Metodo solo Devuelve la vista
            return View();

        }

        [HttpPost]
        public IActionResult Guardar(DetalleModel oDetalle)
        {

            //Metodo recibe el objeto para guardalo en bd 
            if (!ModelState.IsValid)
                return View();

            var respuesta = _detalleDatos.Guardar(oDetalle);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        [HttpPost]      //metodo para modificar el objeto recibido  
        public IActionResult Editar(DetalleModel oDetalle)
        {
            if (!ModelState.IsValid)
                return View();
            var respuesta = _detalleDatos.Editar(oDetalle);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }


        //metodo para recibir el objeto 
        public IActionResult Eliminar(int IdDetalle)
        {
            //Metodo solo devuelve la vista
            var oDetalle = _detalleDatos.Listar(IdDetalle);
            return View(oDetalle);

        }


        [HttpPost]      //metodo para modificar el objeto recibido  
        public IActionResult Eliminar(DetalleModel oDetalle)
        {

            var respuesta = _detalleDatos.Eliminar(oDetalle.IdDetalle);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }
    }
}
