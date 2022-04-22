﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_2
{
    public class AddressBook
    {
        #region Dictionary for Multiple Address Book
        public IDictionary<string, Book> multipleAddressBook = new Dictionary<string, Book>();
        #endregion

        #region Add Multiple AddressBook in Dictionary
        public void AddAddressBook(Book book, string addressBookName)
        {
            multipleAddressBook.Add(addressBookName, book);
            FileIOOperations.WritingAllPersonContactsinFile(multipleAddressBook);
        }
        #endregion

        #region Main Function for Editing,Deleting,Adding Contacts in AddressBook
        public void AddContactsDetailinAddressBook()
        {
            //VARIABLES for Adding,Editing,Deleting Contacts & Address Book
            string chooseOptionToAddContacts = string.Empty;
            string chooseOptionToEditExistingContacts = string.Empty;
            string chooseOptionToDeleteExistingContacts = string.Empty;
            string chooseOptionToAddAddressBook = string.Empty;
            do
            {
                Console.WriteLine("Enter the name of AddressBook: ");
                string nameOfAddressBook = Console.ReadLine();
                Book bookContacts = new Book();
                do
                {
                    Contacts contacts = Contacts.AddContacts();
                    bookContacts.AddContactDetailsInList(contacts);
                    Console.WriteLine("Enter the choice to add more persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                    chooseOptionToAddContacts = Console.ReadLine().ToUpper();
                } while (chooseOptionToAddContacts.Contains("Y"));
                //Option for Editing Contacts
                Console.WriteLine("Enter the choice to edit persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                chooseOptionToEditExistingContacts = Console.ReadLine().ToUpper();
                if (chooseOptionToEditExistingContacts.Contains("Y"))
                {
                    bookContacts.EditContacts();
                }
                //Option for Deletig Contacts
                Console.WriteLine("Enter the choice to delete persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                chooseOptionToDeleteExistingContacts = Console.ReadLine().ToUpper();
                if (chooseOptionToDeleteExistingContacts.Contains("Y"))
                {
                    bookContacts.DeleteContacts();
                }
                AddAddressBook(bookContacts, nameOfAddressBook);
                Console.WriteLine("Enter the choice to add more Address Books: \n \"Yes\" or \"No\"");
                chooseOptionToAddAddressBook = Console.ReadLine().ToUpper();
            } while (chooseOptionToAddAddressBook.Contains("Y"));
        }
        #endregion

        #region Displaying all Contacts present in Multiple AddressBook
        public void DisplayContactsInAddressBookDictionary()
        {
            foreach (var kvp in multipleAddressBook)
            {
                Console.WriteLine($"The name of AddressBook is {kvp.Key} \nDetails in Address Book are:");
                kvp.Value.DisplayContactsDetails();
            }
        }
        #endregion

        #region For Counting Number of Persons in a particular city across Multiple AddressBook
        public void SeachingPersonByCityNameAndCountingAlso()
        {
            Console.WriteLine("Enter the City name: ");
            string cityName = Console.ReadLine();
            int countByCity = 0;
            foreach (var kvp in multipleAddressBook)
            {
                foreach (var v in kvp.Value.listOfContacts)
                {
                    if (v.city == cityName)
                    {
                        Console.WriteLine($"{v.firstName} {v.lastName} lives in this {cityName} city.");
                        countByCity++;
                    }
                }
            }
            Console.WriteLine($"There are {countByCity} persons residing in this {cityName}");
        }
        #endregion

        #region For Counting Number of Person in a particular State across Multiple AddressBook
        public void SeachingPersonByStateNameAndCountingAlso()
        {
            Console.WriteLine("Enter the State name: ");
            string stateName = Console.ReadLine();
            int countByState = 0;
            foreach (var kvp in multipleAddressBook)
            {
                foreach (var v in kvp.Value.listOfContacts)
                {
                    if (v.state == stateName)
                    {
                        Console.WriteLine($"{v.firstName} {v.lastName} lives in this {stateName} state.");
                        countByState++;
                    }
                }
            }
            Console.WriteLine($"There are {countByState} persons residing in this {stateName}");
        }
        #endregion

        #region Sorting by Name, State, City & Zip
        public void SortContactPerson()
        {
            Console.WriteLine("Enter 1-to Sort contact based on First Name");
            Console.WriteLine("Enter 2-to Sort Contact Based on State");
            Console.WriteLine("Enter 3-to Sort Contact based on City");
            Console.WriteLine("Enter 4-to Sort Contact based on zip");
            int sortChoice = Convert.ToInt32(Console.ReadLine());
            foreach (var kvp in multipleAddressBook)
            {
                List<Contacts> sortingListBySelectedField = kvp.Value.listOfContacts;
                CompareContactFields compareContactFields = new CompareContactFields();
                switch (sortChoice)
                {
                    case 1:
                        compareContactFields.CompareByContactDetail = CompareContactFields.SortingType.FIRST_NAME;
                        sortingListBySelectedField.Sort(compareContactFields);
                        break;
                    case 2:
                        compareContactFields.CompareByContactDetail = CompareContactFields.SortingType.STATE;
                        sortingListBySelectedField.Sort(compareContactFields);
                        break;
                    case 3:
                        compareContactFields.CompareByContactDetail = CompareContactFields.SortingType.CITY;
                        sortingListBySelectedField.Sort(compareContactFields);
                        break;
                    case 4:
                        compareContactFields.CompareByContactDetail = CompareContactFields.SortingType.ZIP;
                        sortingListBySelectedField.Sort(compareContactFields);
                        break;
                }
                foreach (Contacts contact in sortingListBySelectedField)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        #endregion
    }
}