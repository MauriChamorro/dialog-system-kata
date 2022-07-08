using System.Collections.Generic;
using System.Diagnostics;
using DialogSystem;
using NUnit.Framework;

namespace DialogSystemTests
{
    [TestFixture]
    public class DialogSystemShould
    {
        //historia de la corona o artefacto que se dejo escrto en un papel que tenia poder
        //generacion tras generación se le dio imporancia
        //cumplia los deseos de quienes lo obtenian (creían)
        //algunos falsos maestros sugetionaron
        //luego de un tiempo, un rey de su pueblo creado gracias al artefacto
        //aparece un sabio, rompe el artefacto y dice que todo fue una ilución, por la sugestión

        //Kata - v1
        //Requerimientos de negocio
        //Darme el primer cuadro de dialgo al comenzar un dialogo
        //existencia del cuadro dialogo
        //Darme el texto de un cuadro de dialgo
        //Darme el la reacción de un cuadro de dialgo en formato texto
        //Darme las acciones posibles de un cuadro de dialogo
        //Obtener el siguiente cuadro de dialgo a partir de una accion tomada a partir de cuadro de dialogo
        //Extra: si el dialogo no tiene action, se quiere que el cliente sepa que tiene que Skipear o Saltar

        //Requerimiento tecnico: manejo de errores de dominio
        //El cliente del dialog system debe saber reconocer qué pasó

        //pre-requisitos
        //una fuente de dialogo correctamente enlazada
        
        //post kata
        //Dar mi dialogo para que ellos juegen
        //Cada uno puede dar un para que los demás jueguen
        
        //Kata - v2
        //Cada acción tiene un variable que:
        //suma un stats, gana el que tiene mejor stats
        //puede llevar al lugar correcto, dando pistas quizas
        //puede conducir obtener la respuesta deseada u objetivo - puzzle
        
        //todo
        //buscar requerimientos reales de juegos de interés
        //algoritmo para leer text dialog en formato json

        private static readonly List<NodeDialog> testDialog = new()
        {
            new NodeDialog(1, "- Hola...", "Action: Levanta su mano izquierda", new List<NodeAction>
            {
                new(1, "action 1", 2)
            }),
            new NodeDialog(2, "- Me llamo ElChapo", "Action: Sonrie", new List<NodeAction>
            {
                new(1, "action 1", 3)
            })
        };

        //
        // [SetUp]
        // public void SetUp()
        // {
        // }

        [Test]
        public void GetFirstNodeDialog()
        {
            var nodeId = 1;
            var dialogSystem = new DialogSystem.DialogSystem(GivenADialogNodeStructure());
            var actualNode = dialogSystem.GetNode(nodeId);

            Debug.Print(actualNode.GetReaction());

            Assert.AreEqual(nodeId, actualNode.GetId());
            Assert.AreEqual("- Hola...", actualNode.GetText());
            Assert.AreEqual("Action: Levanta su mano izquierda", actualNode.GetReaction());
        }

        [TestCase(-1)]
        [TestCase(100)]
        public void GetNodeDoesntExistWhenGetNodeWithWrongId(int nodeIdCase)
        {
            var dialogSystem = new DialogSystem.DialogSystem(GivenADialogNodeStructure());
            var actualNode = dialogSystem.GetNode(nodeIdCase);
            Assert.AreEqual(-1, actualNode.GetId());
        }

        [Test]
        public void GetNodeOptionsByNodeId()
        {
            var nodeId = 1;
            var dialogSystem = new DialogSystem.DialogSystem(GivenADialogNodeStructure());
            var actualNode = dialogSystem.GetNode(nodeId);

            Assert.IsTrue(actualNode.GetActions().Count > 0);
        }

        [Test]
        public void GetNextNodeWhenChoosesAnAction()
        {
            var actionNumber = new NodeActionTaken(1, 1);

            var dialogSystem = new DialogSystem.DialogSystem(GivenADialogNodeStructure());
            var dialogNode = dialogSystem.ChooseAction(actionNumber);

            Assert.AreEqual(2, dialogNode.GetId());
        }

        [Test]
        public void GetEmptyNodeWhenChoosesAnActionWithIncorrectNextNode()
        {
            var actionNumber = new NodeActionTaken(5, 1);

            var dialogSystem = new DialogSystem.DialogSystem(GivenADialogNodeStructure());
            var dialogNode = dialogSystem.ChooseAction(actionNumber);

            Assert.AreEqual(0, dialogNode.GetId());
        }

        [Test]
        public void GetEmptyNodeWhenChoosesAnIncorrectActionNumber()
        {
            var actionNumber = new NodeActionTaken(1, 5);

            var dialogSystem = new DialogSystem.DialogSystem(GivenADialogNodeStructure());
            var dialogNode = dialogSystem.ChooseAction(actionNumber);

            Assert.AreEqual(0, dialogNode.GetId());
        }

        private DialogNodeStructure GivenADialogNodeStructure() =>
            new DialogNodeStructure(testDialog);
    }
}