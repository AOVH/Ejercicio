using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models;

namespace Login.Controllers
{
    public class CuentasController : Controller
    {
        // GET: Cuentas
        public ActionResult Index()
        {
             using (DbContexto db = new DbContexto())
              {
                 return View(db.Database.SqlQuery<Usuario>("Consulta").ToList());
        
        
              }
        }
   
    //Registro
    public ActionResult Registo()
    {
      return View();

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Registo(Usuario usuario)
    {
      if (ModelState.IsValid)
      {
        using (DbContexto db = new DbContexto())
        {
          var name = db.db_usuario.FirstOrDefault(n => n.Usuario_nombre == usuario.Usuario_nombre);
          if (name != null)
          {
           
            ModelState.AddModelError("", "Este usuario ya existe.");
          }
          else
          {
            db.db_usuario.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
            ModelState.Clear();
            ViewBag.Message = usuario.Usuario_nombre + " Bienvenido.";

          }
         
        }
      }
      return View(); 

    }

    //Login
    public ActionResult Login()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Login(Usuario usuario)
    {
      using (DbContexto db = new DbContexto())
      {
        var usr = db.db_usuario.FirstOrDefault(u => u.Usuario_nombre == usuario.Usuario_nombre && u.Contraseña == usuario.Contraseña);
        if (usr != null)
        {
          Session["UsuarioID"] = usr.Id.ToString();
          Session["Usuario_nombre"] = usr.Usuario_nombre.ToString();
          return RedirectToAction("LoggeIn");
        }
        else
        {
          ModelState.AddModelError("", "Tu Usuario o contraseña son incorrectos.");
        }
        return View();
      }
    }
    //LoggeIn
    public ActionResult LoggeIn()
    {
      if (Session["UsuarioID"]!=null)
      {
        return View();
      }
      else
      {
        return RedirectToAction("Login");
      }

    }

    //Eliminar
    public ActionResult Eliminar(int id)
    {
      using (DbContexto db = new DbContexto())
      {
        Usuario usr = db.db_usuario.Find(id);
        db.db_usuario.Remove(usr);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

    }


  }
}