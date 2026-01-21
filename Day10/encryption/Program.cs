// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using System.Security.Cryptography;

//Creating a hash value for a password using SHA256
     string password = "MySecurePassword";

     string hashedPassword;

     using (SHA256 sha256 = SHA256.Create())
     {
         byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
         byte[] hashBytes = sha256.ComputeHash(passwordBytes);
         hashedPassword = Convert.ToBase64String(hashBytes);
     }

     Console.WriteLine("Stored Hash: " + hashedPassword);

     // Matching the password during login with the help of hash value
     string loginPassword = "MySecurePassword";
     string loginHash;

     using (SHA256 sha256 = SHA256.Create())
     {
         byte[] loginBytes = Encoding.UTF8.GetBytes(loginPassword);
         byte[] loginHashBytes = sha256.ComputeHash(loginBytes);
         loginHash = Convert.ToBase64String(loginHashBytes);
     }

     bool isValid = hashedPassword == loginHash;

     Console.WriteLine("Password Match: " + isValid);