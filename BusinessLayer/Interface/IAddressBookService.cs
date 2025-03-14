using ModelLayer.DTO;
using ModelLayer.Model;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    /// <summary>
    /// Interface for Address Book Business Layer.
    /// Defines CRUD operations for managing address book contacts and authhentication
    /// </summary>
    public interface IAddressBookService
    {
        IEnumerable<AddressBookEntry> GetAllContacts();
        AddressBookEntry GetContactById(int id);
        AddressBookEntry AddContact(AddressBookEntry contact);
        bool UpdateContact(int id, AddressBookEntry contact);
        bool DeleteContact(int id);
        string Register(UserDTO userDto);
        string Login(string email, string password);
<<<<<<< HEAD
=======
        void ForgotPassword(string email);
        void ResetPassword(string token, string newPassword);
>>>>>>> feature-password-reset
    }
}
