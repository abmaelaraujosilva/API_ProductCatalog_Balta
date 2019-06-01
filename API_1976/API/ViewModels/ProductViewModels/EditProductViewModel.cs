using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace API.ViewModels.ProductViewModels
{
    public class EditProductViewModel : Notifiable, IValidatable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int IDCategory { get; set; }
        public string Category { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMaxLen(Title, 120, "Title", "O titulo deve conter até 120 caracteres")
                .HasMinLen(Title, 3, "Title",   "O titulo deve conter pelo menos 3 caracteres")
                .IsGreaterThan(Price, 0, "Price", "O Proço deve ser maior que zero")
                );
        }
    }
}
