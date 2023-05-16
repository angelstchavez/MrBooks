using Microsoft.AspNetCore.Mvc;
using MrBooks.Web.Models;
using MrBooks.Web.Repository;

namespace MrBooks.Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de libros.
    /// </summary>
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = new BookRepository();

        /// <summary>
        /// Acción para obtener todos los libros.
        /// </summary>
        /// <returns>Vista que muestra la lista de libros.</returns>
        public IActionResult GetBooks()
        {
            var books = bookRepository.GetBooks();
            return View(books);
        }

        /// <summary>
        /// Acción para mostrar el formulario de guardado de libros.
        /// </summary>
        /// <returns>Vista con el formulario de guardado de libros.</returns>
        public IActionResult Save()
        {
            return View();
        }

        /// <summary>
        /// Acción para guardar un libro en la base de datos.
        /// </summary>
        /// <param name="book">Libro a guardar.</param>
        /// <returns>Redirecciona a la acción "GetBooks" si se guarda correctamente, de lo contrario, muestra la vista de guardado.</returns>
        [HttpPost]
        public IActionResult Save(Book book)
        {
            var result = bookRepository.Save(book);

            if (result)
                return RedirectToAction("GetBooks");
            else
                return View();
        }
    }
}
