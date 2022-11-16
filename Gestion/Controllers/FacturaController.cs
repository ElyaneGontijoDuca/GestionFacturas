using Microsoft.AspNetCore.Mvc;

using Gestion.Datos;
using Gestion.Models;

namespace Gestion.Controllers
{
    public class FacturaController : Controller
    {
        FacturaDatos _facturaDatos = new FacturaDatos();

        public IActionResult Listar()
        {
            //La vista mostrará una lista deFacturas
            var oLista = _facturaDatos.Listar();


            return View(oLista);
        }

        //Recibir nombre deFactura 
        public IActionResult Consulta(int idfactura)
        {
            //Metodo solo devuelve la vista
            var olista = _facturaDatos.ConsultaFactura(idfactura);
            return View(olista);

        }

        public IActionResult Guardar()
        {
            //Metodo solo Devuelve la vista
            return View();

        }

        [HttpPost]
        public IActionResult Guardar(FacturaModel ofactura)
        {

            //Metodo recibe el objeto para guardalo en bd 
            if (!ModelState.IsValid)
                return View();

            var respuesta = _facturaDatos.Guardar(ofactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        //metodo para recibir el objeto 
        public IActionResult Editar(int IdFactura)
        {
            //Metodo solo devuelve la vista
            var ofactura = _facturaDatos.Obtener(IdFactura);
            return View(ofactura);

        }


        [HttpPost]      //metodo para modificar el objeto recibido  
        public IActionResult Editar(FacturaModel ofactura)
        {
            if (!ModelState.IsValid)
                return View();
            var respuesta = _facturaDatos.Editar(ofactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }


        //metodo para recibir el objeto 
        public IActionResult Eliminar(int IdFactura)
        {
            //Metodo solo devuelve la vista
            var ofactura = _facturaDatos.Obtener(IdFactura);
            return View(ofactura);

        }


        [HttpPost]      //metodo para modificar el objeto recibido  
        public IActionResult Eliminar(FacturaModel ofactura)
        {

            var respuesta = _facturaDatos.Eliminar(ofactura.IdFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }
    }
}
