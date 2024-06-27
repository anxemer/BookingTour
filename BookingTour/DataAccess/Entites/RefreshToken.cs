using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    public partial class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;

        public string Token { get; set; } = null!;
        public DateTime IssuedAt { get; set; }
        public DateTime ExpriedAt { get; set; }
        public string JwtId { get; set; } = null!;
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }

    }
}
