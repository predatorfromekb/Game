using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Model;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var graph = Graph.MakeGraph(
                0, 1,
                2, 3,
                4, 5
            );

            var nodeDiameter = 40;
            var bigRadius = 200;
            var center = new Point(300, 300);
            var angle = 360.0 / graph.Length;
            var points = Enumerable.Range(0, graph.Length)
                .Select(e => new Point(
                    center.X + (int) (bigRadius * Math.Sin(e * Math.PI * angle / 180.0 )), 
                    center.Y + (int) (bigRadius * Math.Cos(e * Math.PI * angle / 180.0 ))
                    ))
                .ToArray();

            Paint += (sender, args) =>
            {
                var graphics = CreateGraphics();
                foreach (var node in graph.Nodes)
                {
                    foreach (var incidentNode in node.IncidentNodes)
                    {
                        var point = points[node.NodeNumber];
                        if (incidentNode.NodeNumber >= node.NodeNumber)
                        {
                            continue;
                        }
                        
                        var incidentPoint = points[incidentNode.NodeNumber];
                        graphics.DrawLine(Pens.Green, point, incidentPoint);
                    }
                }
                
                
                foreach (var node in graph.Nodes)
                {
                    var point = points[node.NodeNumber];
                    graphics.FillEllipse(
                        Brushes.Blue,
                        new Rectangle(
                            point.X - nodeDiameter / 2, 
                            point.Y -nodeDiameter / 2, 
                            nodeDiameter, 
                            nodeDiameter));

                    var label = new Label()
                    {
                        Text = node.NodeNumber.ToString(),
                        Location = point,
                        BackColor = Color.Red,
                        Width = 20
                    };
                    
                    Controls.Add(label);
                    
                    

                    // var incidentNodes = graph.
                    // graphics.DrawLine();
                }
            };
            InitializeComponent();
        }
    }
}