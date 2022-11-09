using Microsoft.AspNetCore.Mvc;

using Gestion.Datos;
using Gestion.Models;

namespace Gestion.Controllers
{
    public class MantenedorController : Controller
    {
        ClienteDatos _clienteDatos = new ClienteDatos(); 

        public IActionResult Listar()
        {
            //La vista mostrará una lista de Clientes
            var oLista = _clienteDatos.Listar(); 


            return View(oLista);
        }

      
        public IActionResult Guardar()
        {
            //Metodo solo Devuelve la vista
            return View();

        }

        [HttpPost]
        public IActionResult Guardar(ClienteModel oCliente)
        {

            //Metodo recibe el objeto para guardalo en bd 
            if (!ModelState.IsValid)
                return View();

            var respuesta = _clienteDatos.Guardar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }

        //metodo para recibir el objeto 
        public IActionResult Editar(int IdCliente)
        {
            //Metodo solo devuelve la vista
            var oCliente = _clienteDatos.Obtener(IdCliente);
            return View(oCliente);

        }


        [HttpPost]      //metodo para modificar el objeto recibido  
        public IActionResult Editar(ClienteModel ocliente)
        {
           if(!ModelState.IsValid)
                return View();
            var respuesta = _clienteDatos.Editar(ocliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();

        }

        
        //metodo para recibir el objeto 
        public IActionResult Eliminar(int IdCliente)
        {
            //Metodo solo devuelve la vista
            var oCliente = _clienteDatos.Obtener(IdCliente);
            return View(oCliente);

        }


        [HttpPost]      //metodo para modificar el objeto recibido  
        public IActionResult Eliminar(ClienteModel ocliente)
        {
           
            var respuesta = _clienteDatos.Eliminar(ocliente.IdCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }
    }
}
