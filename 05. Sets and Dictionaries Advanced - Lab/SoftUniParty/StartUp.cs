namespace SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            // Make list with invited guests.
            var guest = Console.ReadLine();
            var invitedGuests = new HashSet<string>();
            
            while (guest?.ToLower() != "party")
            {
                if (guest.Length == 8)
                {
                    invitedGuests.Add(guest);
                }

                guest = Console.ReadLine();
            }

            // Guests comes to the party.
            var guestOnParty = Console.ReadLine();
            var partyGuests = new HashSet<string>();

            while (guestOnParty?.ToLower() != "end")
            {
                partyGuests.Add(guestOnParty);
                invitedGuests.Remove(guestOnParty);
                guestOnParty = Console.ReadLine();
            }

            // Print guests and guests count.           
            Console.WriteLine(invitedGuests.Count);   
            
            foreach (var missingGuest in invitedGuests.Where(x => Char.IsDigit(x[0])))
            {
                Console.WriteLine(missingGuest);
            }
            foreach (var missingGuest in invitedGuests.Where(x => !Char.IsDigit(x[0])))
            {
                Console.WriteLine(missingGuest);
            }
        }
    }
}
