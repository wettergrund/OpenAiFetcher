using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAi
{
    internal class MessageModel
    {

        public enum Role {
            system,
            user
            }

        private Role UserRole { get; set; }
        public string Message { get; set; }

        public string role => UserRole.ToString().ToLowerInvariant();

        public MessageModel(Role userRole, string message)
        {
            UserRole = userRole;
            Message = message;
        }

        public object ToRequestMessage()
        {
            return new { role = this.role, content = this.Message };
        }

    }
}
