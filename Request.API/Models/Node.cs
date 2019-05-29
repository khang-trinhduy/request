using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Abstractions;

namespace Request.API.Models
{
    public class Node : AggregateRoot
    {
        public List<Node> Childs { get; set; }
        public Node Parent { get; set; }
        public bool Iscompleted { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Action> Actions { get; set; }
        public List<Role> Roles { get; set; }
        [ForeignKey("ProcessId")]
        public Process Process { get; set; }
        public int ProcessId { get; set; }
        
        

        public bool IsRoot() {
            return Parent is null && Level is 0;
        }
        public bool IsLeaf() {
            return Childs.Count <= 0;
        }
        public Node(Node parent, List<Node> childs, bool iscompleted = false) : base() {
            this.Childs = childs;
            this.Parent = parent;
            this.Iscompleted = iscompleted;
        }
        public Node() : base(){
            Childs = new List<Node>();
        }
        public Node Move(string name) {
            if (this.IsLeaf())
            {
                throw new NullReferenceException(nameof(Node));
            }
            var child = Childs.Find(c => c.Name == name);
            if (child is null)
            {
                throw new NullReferenceException(nameof(Node));
            }
            return child;
        }
        public Node Reverse() {
            if(this.IsRoot()) {
                throw new NullReferenceException(nameof(Node));
            }
            return this.Parent;
        }
        public void AddChild(Node child) {
            if (child.Level <= Level) {
                throw new InvalidOperationException(nameof(Node));
            }
            if (child is null) {
                throw new NullReferenceException(nameof(child));
            }
            if (Childs is null) {
                Childs = new List<Node>();
            }
            Childs.Add(child);
            child.Parent = this;
        }
        public int AddRangeChilds(List<Node> childs) {
            if (childs is null) {
                throw new NullReferenceException(nameof(childs));
            }
            int success = 0;
            foreach (var child in childs)
            {
                if (child is null)
                {
                    continue;
                }
                if (child.Level <= Level) {
                    continue;
                }
                if (Childs is null) {
                    Childs = new List<Node>();
                }
                Childs.Add(child);
                success++;
            }
            return success;
        }
        public int Remove() {
            int count = 0;
            if (this is null) {
                return count;
            }
            if (this.Childs != null) {
                foreach (var child in Childs)
                {
                    count += child.Remove();
                }
            }
            count++;
            this.Childs = null;
            this.Parent = null;
            this.Name = null;
            return count;
        }
        public List<List<List<string>>> GetPossiblePath() {
            if (this is null)
            {
                return null;
            }
            if (this.Childs is null)
            {
                return null;
            }
            List<List<List<string>>> paths = new List<List<List<string>>>();
            foreach (var child in Childs)
            {
                paths.Add(GetPath(new List<List<string>>(), new List<string>{Name}, child, 1));
            }
            return paths;
        }
        public List<List<string>> GetPath(List<List<string>> paths, List<string> nodes, Node node, int length) {
            if (node is null) {
                return null;
            }
            if (length < nodes.Count) {
                nodes[length] = node.Name;
            }
            else {
                List<string> tmp = new List<string>();
                tmp = nodes;
                nodes = new List<string>(tmp);
                nodes.Add(node.Name);
            }
            length++;
            // nodes.Add(Name);

            if (node.IsLeaf()) {
                paths.Add(nodes);
            }

            foreach (var child in node.Childs)
            {
                GetPath(paths, nodes, child, length);
            }
            return paths;
        }
    }
}