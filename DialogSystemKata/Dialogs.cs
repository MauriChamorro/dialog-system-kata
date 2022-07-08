using DialogSystem;

namespace DialogSystemKata;

public class Dialogs
{
    public static readonly List<NodeDialog> Dialog = new()
    {
        new NodeDialog(1, "- Hola...", "(Levanta su mano izquierda)", new List<NodeAction>
        {
            new(1, "Saludar", 2),
            new(3, "Irse", 3)
        }),
        new NodeDialog(2, "- Me llamo ElChapo", "(Se nota una sonrisa siniestra)", new List<NodeAction>
        {
            new(1, "Pegarle", 4),
            new(2, "Pegarle e irse", 5),
            new(3, "...", 6)
        })
    };
}