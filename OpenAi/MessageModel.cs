using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAi
{
    internal class MessageModel
    {
        public enum Role
        {
            System, 
            User    
        }

        private Role UserRole { get; set; }
        public string Message { get; set; }

        // Property to get the role in the format expected by the API
        public string role => UserRole.ToString().ToLowerInvariant();

        // Constructor to set the role and message
        public MessageModel(Role userRole, string message)
        {
            UserRole = userRole;
            Message = message;
        }

        // Method to create the content field for serialization
        public object ToRequestMessage()
        {
            return new { role = this.role, content = this.Message };
        }

    }
}
