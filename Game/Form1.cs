using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Model;

namespace Game
{
    public partial class Form1 : Form
    {
        // TODO
        // 1. 2 балла - Динамическое добавление вершин и ребер + удаление вершин и ребер
        // 2. 2 балла - BFS и DFS - визуализация процесса
        // 3. 2 балла - Поиск кратчайшего пути - визуализация результата
        // 4. 2 балла - drag&drop
        public Form1()
        {
            var graph = Graph.MakeGraph(
                0, 1,
                2, 3,
                4, 5
            );
            graph.Connect(graph.AddNode().NodeNumber, 1);

            var buttonSize = 30;
            var bigRadius = 200;
            
            var buttons = new Dictionary<int, Button>();

            var addNodeBtn = new Button()
            {
                Text = "Add node",
                Location = new Point(0,0),
                Width = 100,
                Height = 50,
            };
            addNodeBtn.Click += (sender, args) =>
            {
                graph.AddNode();
                Invalidate();
            };
            
            Controls.Add(addNodeBtn);

            Paint += (sender, args) =>
            {
                var center = new Point(300, 300);
                var angle = 360.0 / graph.Length;
                var points = Enumerable.Range(0, graph.Length)
                    .Select(e => new Point(
                        center.X + (int) (bigRadius * Math.Sin(e * Math.PI * angle / 180.0 )), 
                        center.Y + (int) (bigRadius * Math.Cos(e * Math.PI * angle / 180.0 ))
                    ))
                    .ToArray();
                
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
                    // graphics.FillEllipse(
                    //     Brushes.Blue,
                    //     new Rectangle(
                    //         point.X - nodeDiameter / 2, 
                    //         point.Y -nodeDiameter / 2, 
                    //         nodeDiameter, 
                    //         nodeDiameter));

                    var pt = new Point(point.X - buttonSize / 2, point.Y - buttonSize / 2);
                    if (buttons.ContainsKey(node.NodeNumber))
                    {
                        buttons[node.NodeNumber].Location = pt;
                    }
                    else
                    {
                        var button = new Button()
                        {
                            Text = node.NodeNumber.ToString(),
                            Location = pt,
                            BackColor = Color.Red,
                            Width = buttonSize,
                            Height = buttonSize,
                        };
                        Controls.Add(button);
                        buttons.Add(node.NodeNumber, button);
                    }
                }
            };
            InitializeComponent();
        }
    }
}