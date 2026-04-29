namespace task.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Location { get; set; } = ""; // Uçuş istiqaməti
    public int Count { get; set; }             // Seçilən yer sayı
    public int Price { get; set; }             // Ümumi qiymət
    public string SideNumber { get; set; }     // Seçilən oturacaq nömrələri (məs: "A1, A2")
}