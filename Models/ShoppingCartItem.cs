﻿namespace SistemaCos_001.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public stock Producto { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; } 
    }
}
