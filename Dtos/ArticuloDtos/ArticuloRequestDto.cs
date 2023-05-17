namespace NetSoloTalento.Dtos.ArticuloDtos;

public class ArticuloRequestDto {
    public int Id { get; set; }
    public string Código { get; set; }
    public string Descripción { get; set; }
    public decimal Precio { get; set; }
    public string Imagen { get; set; }
    public int Stock { get; set; }
}