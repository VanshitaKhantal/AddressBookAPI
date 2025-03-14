using ModelLayer.Model;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    /// <summary>
    /// Interface for Address Book Repository Layer.
    /// Defines CRUD operations for managing address book contacts and authentication
    /// </summary>
    public interface IAddressBookRL
    {
        IEnumerable<AddressBookEntry> GetAll();
        AddressBookEntry GetById(int id);
        AddressBookEntry AddContact(AddressBookEntry contact);
        bool UpdateContact(int id, AddressBookEntry contact);
        bool DeleteContact(int id);
<<<<<<< HEAD
        UserEntity RegisterUser(UserEntity user);
        UserEntity GetUserByEmail(string email);
=======
        void UpdateUser(UserEntity user);
        UserEntity RegisterUser(UserEntity user);

        UserEntity GetUserByEmail(string email);
        void SaveResetToken(int userId, string token);
        int GetUserIdByResetToken(string token);
        void UpdatePassword(int userId, string newPassword);
>>>>>>> feature-password-reset
    }
}
