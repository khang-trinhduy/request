using Catalog.API.Model;
using Dms.API.Models;
using Identity.API.Models;
using Newtonsoft.Json;
using Request.API.Models;
using SharedKernel.Abstractions;
using SharedKernel.Enums;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Request.API.ViewModels;
using System.IO;

namespace Request.API.Model
{
    public class Request : AggregateRoot
    {
        [ForeignKey("ProcessId")]
        public Process Process { get; set; }
        public int ProcessId { get; set; }
        [Required]
        public string Title { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public State CurrentState { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateRequested { get; set; }
        public List<ActivityLog> Histories { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Data> Data { get; set; }
        public Node CurrentNode { get; set; }

        //public Transition Transition { get; set; }


        //protected Request() : base()
        //{
        //    List<NewAction> actions = new List<NewAction>();
        //    List<State> states = new List<State>();
        //    List<TransitionRule> rules = new List<TransitionRule>();
        //    Process = new Process("Template");
        //}

        public Request() : base()
        {
            
        }
        public Request(Process process, string title, int userId, string userName, State currentState, DateTime dateRequested, List<ActivityLog> histories)
        {
            Process = process;
            Title = title;
            UserId = userId;
            UserName = userName;
            CurrentState = currentState;
            DateRequested = dateRequested;
            Histories = histories;
        }

        public void InsertData(DataCreateModel data, string activity)
        {
            Data new_data = null;
            if (CurrentState != null) {
                var new_activity = CurrentState.Activities.FirstOrDefault(a => a.Name == activity);
                if (data.DataType.Equals(DataType.Comment))
                {
                    new_data = new Comment
                    {
                        Messages = data.Messages,
                        Topic = data.Topic,
                        Emoji = data.Emoji,
                        DataType = DataType.Comment,
                        UserId = data.UserId,
                        Request = data.Request

                    };
                }
                else if (data.DataType.Equals(DataType.Email))
                {
                    new_data = new Email
                    {
                        Contents = data.Contents,
                        Subject = data.Subject,
                        DataType = DataType.Email,
                        UserId = data.UserId,
                        Request = data.Request,
                        Server = data.Server,
                        Client = data.Client,
                        Attach = data.Attach,
                        ConfirmEmail = data.ConfirmEmail,
                        ConfirmPass = data.ConfirmPass,
                        From = data.From,
                        To = data.To,
                        IsSent = data.IsSent,
                    };
                }
                else if (data.DataType.Equals(DataType.TalentLeave))
                {
                    new_data = new TLeave
                    {
                        DataType = DataType.TalentLeave,
                        UserId = data.UserId,
                        Request = data.Request,
                        AbsentName = data.AbsentName,
                        ApproverName = data.ApproverName,
                        DayOff = data.DayOff,
                        IsDone = data.IsDone,
                        Reason = data.Reason,
                        IsReallyNotApproved = data.IsReallyNotApproved

                    };
                }
                else if (data.DataType.Equals(DataType.Campaign)) {
                    new_data = new Campaign {
                        DataType = DataType.Campaign,
                        CampaignName = data.CampaignName,
                        IsRunning = data.IsRunning
                    };
                }
                else if (data.DataType == DataType.Contact) {
                    new_data = new Contact {
                        Age = data.Age,
                        FullName = data.FullName,
                        Email = data.Email,
                        PhoneNumber = data.PhoneNumber,
                        DataType = DataType.Contact
                    };
                }
                if (new_data != null)
                {
                    if (new_activity != null)
                    {
                        if(new_activity.Data is null)
                        {
                            new_activity.Data = new List<Data>();
                        }
                        new_activity.Data.Add(new_data);
                    }
                    if (Data == null) {
                        Data = new List<Data>();
                        
                    }
                    Data.Add(new_data);
                }
            } 
            else if (CurrentNode != null) {
                var new_activity = CurrentNode.Activities.FirstOrDefault(a => a.Name == activity);
                if (data.DataType.Equals(DataType.Comment))
                {
                    new_data = new Comment
                    {
                        Messages = data.Messages,
                        Topic = data.Topic,
                        Emoji = data.Emoji,
                        DataType = DataType.Comment,
                        UserId = data.UserId,
                        Request = data.Request

                    };
                }
                else if (data.DataType.Equals(DataType.Email))
                {
                    new_data = new Email
                    {
                        Contents = data.Contents,
                        Subject = data.Subject,
                        DataType = DataType.Email,
                        UserId = data.UserId,
                        Request = data.Request,
                        Server = data.Server,
                        Client = data.Client,
                        Attach = data.Attach,
                        ConfirmEmail = data.ConfirmEmail,
                        ConfirmPass = data.ConfirmPass,
                        From = data.From,
                        To = data.To,
                        IsSent = data.IsSent,
                    };
                }
                else if (data.DataType.Equals(DataType.TalentLeave))
                {
                    new_data = new TLeave
                    {
                        DataType = DataType.TalentLeave,
                        UserId = data.UserId,
                        Request = data.Request,
                        AbsentName = data.AbsentName,
                        ApproverName = data.ApproverName,
                        DayOff = data.DayOff,
                        IsDone = data.IsDone,
                        Reason = data.Reason,
                        IsReallyNotApproved = data.IsReallyNotApproved

                    };
                }
                if (new_data != null)
                {
                    Data.Add(new_data);
                    if (new_activity != null)
                    {
                        if(new_activity.Data is null)
                        {
                            new_activity.Data = new List<Data>();
                        }
                        new_activity.Data.Add(new_data);
                    }
                }
            }
            

        }

        public bool IsCompleted()
        {
            if (CurrentState != null)
            {
                if (CurrentState.StateType == StateType.end) {
                    foreach (var activity in CurrentState.Activities)
                    {
                        var task = Tasks.FirstOrDefault(t => t.Activity.Id == activity.Id);
                        if (!task.IsDone && activity.IsRequired)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            else if (CurrentNode != null)
            {
                if (CurrentNode.Childs != null)
                {
                    foreach (var activity in CurrentNode.Activities)
                    {
                        var task = Tasks.FirstOrDefault(t => t.Activity.Id == activity.Id);
                        if (!task.IsDone && activity.IsRequired) {
                            return false;
                        }
                    }
                    return true;
                }
                return true;
            }
            return false;
        }

        public State Transit(string action, string source, string role, string activity, 
                string approver, List<DataCreateModel> data, bool doactivity = false, bool trigger = false)
        {
            var task = Tasks.FirstOrDefault(t => t.Activity.Name.ToLower() == activity.ToLower());
            if (task is null)
            {
                throw new NullReferenceException(nameof(task));
            }
            if (action == "approve")
            {
                CompleteTask(task);           
            }
            if (source != CurrentState.Name)
            {
                
                throw new Exception($"input state not match current state {CurrentState.Name}");
            }
            List<string> incompleted = new List<string>();
            foreach (var item in CurrentState.Activities)
            {
                if (!item.IsRequired)
                {
                    continue;
                }
                if (action == "approve")
                {
                    if (Histories.FirstOrDefault(e => e.Activity.Name.Equals(item.Name) && e.IsCompleted == true) is null)
                    {
                        incompleted.Add(item.Name);

                    }
                }
            }
            if (incompleted.Count > 0)
            {
                throw new Exception($"you must complete all activities [{string.Join(", ", incompleted)}] before submit this action");
            }
            if (doactivity)
            {
                var new_activity = CurrentState.Activities.FirstOrDefault(s => s.Name == activity);
                if (new_activity is null)
                {
                    throw new NullReferenceException(nameof(new_activity));
                }
                if (new_activity.ActivityType == ActivityType.Absent)
                {
                    ((TLActivityOperator)new_activity).ApproverName = approver;

                }
                foreach (var item in data)
                {
                    var new_data = Data.FirstOrDefault(d => d.Id == item.Id);
                    if (new_data is null)
                    {
                        continue;
                    }
                    new_activity.DoActivityThings(new_data);
                }
            }
            if (trigger) {
                var tmp = Process.Rules.FirstOrDefault(e => e.CurrentState.Name == source);
                if (tmp == null) {
                    throw new Exception(nameof(TransitionRule));
                }
                var tmp_trigger = tmp.Trigger;
                if (tmp_trigger == null)
                {
                    throw new Exception(nameof(Trigger));
                }
                var conseq = tmp_trigger.Consequence;
                var events = tmp_trigger.Events;
                if (conseq.Name == "Campaign") {
                    var campaign = Data.FirstOrDefault(d => d.DataType == DataType.Campaign);
                    if (campaign == null) {
                        throw new NullReferenceException(nameof(Campaign));
                    }
                    if (conseq.Method == "AddContact") {
                        var e = events.First();
                        var c = e.Conditions.First();
                        if (c.Operator.ToLower() == "greaterorequal" && c.Param.ToLower() == "age" && c.Type.ToLower() == "integer") {
                            var threshold = Convert.ToInt16(c.Threshold);
                            var numOfContact = AddContact((Campaign)campaign, threshold);
                        }
                    }
                }
            }
            // if (CurrentState.StateType == StateType.end)
            // {
            //     throw new InvalidOperationException("Request completed");
            // }
            if (Process.States.FirstOrDefault(s => s.Name == source).StateType == StateType.end) {
                if (action is "approve")
                {
                    return Process.States.FirstOrDefault(s => s.Name == source);

                }
                throw new NullReferenceException(nameof(State));
            }
            return CurrentState = Process.TransitFrom(source, action, role);
        }
        public int AddContact(Campaign campaign, int threshold) {
            int res = 0;
            campaign.Subscribers = new List<Contact>();
            foreach (var c in Data.Where(d => d.DataType == DataType.Contact))
            {
                var contact = c as Contact;
                if (contact.Age > threshold) {
                    campaign.Subscribers.Add(contact);
                    res++;
                }   
            }
            return res;
        }
        public void Transit(string currentstate)
        {
            var state = Process.States.FirstOrDefault(s => s.Name == currentstate);
            if (state is null)
            {
                throw new NullReferenceException(nameof(state));
            }
            List<string> incompleted = new List<string>();
            foreach (var item in CurrentState.Activities)
            {
                if (!item.IsRequired)
                {
                    continue;
                }
                if (Histories.FirstOrDefault(e => e.Activity.Name.Equals(item.Name) && e.IsCompleted == true) is null)
                {
                    incompleted.Add(item.Name);
                }
            }
            if (incompleted.Count > 0)
            {
                throw new Exception($"you must complete all activities [{string.Join(", ", incompleted)}] before submit this action");
            }
            if (CurrentState.StateType == StateType.end)
            {
                return;
            }
            CurrentState = Process.TransitFrom(state.Name);
        }

        public List<Models.Action> GetAvailableActions(string currentstate)
        {
            return Process.GetAvailableActions(currentstate);
        }

        public List<Activity> GetActivities(State state)
        {
            if (state is null)
            {
                throw new NullReferenceException($"state cannot be null");
            }
            return Process.GetActivities(state);
        }

        public static Model.Request CreateFlow(RequestCreateModel model1)
        {
            if (model1 is null)
            {
                return null;
            }
            if (model1.Process is null)
            {
                return null;
            }
            Process new_process = new Process
            {
                Name = model1.Process.Name,
                Actions = new List<Models.Action>(),
                States = new List<State>(),
                Rules = new List<TransitionRule>(),
                Roles = new List<Role>(),
                Activities = new List<Activity>()
            };
            foreach (var state in model1.Process.States)
            {
                State new_state = new State
                {
                    StateType = state.StateType,
                    Name = state.Name,
                    Description = state.Description,
                    Activities = new List<Activity>(),
                    Roles = new List<Role>(),
                    ETA = state.ETA
                };
                foreach (var activity in state.Activities)
                {
                    if (activity.ActivityType == ActivityType.Email)
                    {
                        Activity new_activity = new EmailActivityOperator
                        {
                            ActivityType = activity.ActivityType,
                            Name = activity.Name,
                            Description = activity.Description,
                            Duration = activity.Duration,
                            IsRequired = activity.IsRequired,
                            Discriminator = "EMAIL",
                            Roles = new List<Role>(),
                            Data = new List<Data>()
                        };
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role new_role = new Role
                                {
                                    Name = role.Name
                                };
                                new_process.Roles.Add(new_role);
                                new_activity.Roles.Add(new_role);
                            }
                            new_process.Activities.Add(new_activity);
                            new_state.Activities.Add(new_activity);

                        }
                    }
                    else if (activity.ActivityType == ActivityType.Absent)
                    {
                        Activity new_activity = new TLActivityOperator
                        {
                            ActivityType = activity.ActivityType,
                            Name = activity.Name,
                            Description = activity.Description,
                            Duration = activity.Duration,
                            IsRequired = activity.IsRequired,
                            Discriminator = "TALENT-LEAVE",
                            Roles = new List<Role>(),
                            Data = new List<Data>(),
                            AbsentName = activity.AbsentName,
                            ApproverName = activity.ApproverName,
                            DayOff = activity.DayOff,
                            IsReallyNotApproved = activity.IsReallyNotApproved,
                            Reason = activity.Reason
                        };
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role new_role = new Role
                                {
                                    Name = role.Name
                                };
                                new_process.Roles.Add(new_role);
                                new_activity.Roles.Add(new_role);
                                new_state.Roles.Add(new_role);
                            }
                            new_process.Activities.Add(new_activity);
                            new_state.Activities.Add(new_activity);

                        }

                    }
                    else if (activity.ActivityType == ActivityType.Generic)
                    {
                        Activity new_activity = new GenericActivityOperator
                        {
                            ActivityType = activity.ActivityType,
                            Name = activity.Name,
                            Description = activity.Description,
                            Duration = activity.Duration,
                            IsRequired = activity.IsRequired,
                            Roles = new List<Role>(),
                            Data = new List<Data>(),

                        };
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role new_role = new Role
                                {
                                    Name = role.Name
                                };
                                new_process.Roles.Add(new_role);
                                new_activity.Roles.Add(new_role);
                                new_state.Roles.Add(new_role);
                            }
                            new_process.Activities.Add(new_activity);
                            new_state.Activities.Add(new_activity);

                        }

                    }
                    else if (activity.ActivityType == ActivityType.Campaign)
                    {
                        Activity new_activity = new CampaignActivityOperator
                        {
                            ActivityType = activity.ActivityType,
                            Name = activity.Name,
                            Description = activity.Description,
                            Duration = activity.Duration,
                            IsRequired = activity.IsRequired,
                            CampaignName = activity.CampaignName,
                            Subscribers = new List<Contact>(),
                            IsRunning = activity.IsRunning,
                            Roles = new List<Role>(),
                            Data = new List<Data>(),
                            Discriminator = "CAMPAIGN"
                        };
                        // if (activity.Subscribers != null) 
                        // {
                        //     foreach (var item in activity.Subscribers)
                        //     {
                        //         ((CampaignActivityOperator)new_activity).Subscribers.Add(new Contact {
                        //             FullName = item.FullName,
                        //             Email = item.Email,
                        //             PhoneNumber = item.PhoneNumber,
                        //             Age = item.Age,
                        //             DataType = DataType.Contact
                        //         })
                        //     }
                        // }
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role new_role = new Role
                                {
                                    Name = role.Name
                                };
                                new_process.Roles.Add(new_role);
                                new_activity.Roles.Add(new_role);
                                new_state.Roles.Add(new_role);
                            }
                            new_process.Activities.Add(new_activity);
                            new_state.Activities.Add(new_activity);

                        }

                    }
                }
                new_process.States.Add(new_state);
            }
            if (model1.Process.Actions != null)
            {
                foreach (var action in model1.Process.Actions)
                {
                    var new_action = new Models.Action
                    {
                        Name = action.Name,
                        Description = action.Description
                    };
                    new_process.Actions.Add(new_action);
                }
            }
            if (model1.Process.Rules != null)
            {
                foreach (var rule in model1.Process.Rules)
                {
                    TransitionRule new_rule = new TransitionRule
                    {
                        CurrentState = new_process.States.FirstOrDefault(s => s.Name == rule.CurrentState.Name),
                        NextState = new_process.States.FirstOrDefault(s => s.Name == rule.NextState.Name),
                        Action = new_process.Actions.FirstOrDefault(a => a.Name == rule.Action.Name)
                    };
                    if (rule.Trigger != null) {
                        var new_trigger = new Trigger {
                                Consequence = rule.Trigger.Consequence,
                                Events = rule.Trigger.Events
                        };
                        new_rule.Trigger = new_trigger;
                    }
                    new_process.Rules.Add(new_rule);
                }

            }
            var new_request = new Model.Request
            {
                Title = model1.Title,
                UserId = model1.UserId,
                UserName = model1.UserName,
                CurrentState = new_process.States.FirstOrDefault(s => s.StateType == StateType.start),
                DateRequested = model1.DateRequested,
                Histories = new List<ActivityLog>(),
                Tasks = new List<Model.Task>(),
                Data = new List<Data>()
            };

            new_request.Process = new_process;
            new_request.Tasks = new List<Model.Task>();
            foreach (var activity in new_process.Activities)
            {
                new_request.Tasks.Add(new Model.Task
                {
                    Activity = activity,
                    IsDone = false
                });
            }

            return new_request;
        }

        public async void CompleteTask(Task task, bool autoadvancetonextstate = false)
        {
            if (task is null)
            {
                throw new NullReferenceException(nameof(task));
            }
            // var data = Data.FirstOrDefault(e => e.Activity.Name == task.Activity.Name && e.Activity.ActivityType == task.Activity.ActivityType);
            // if (data != null)
            // {
            //     task.Activity.DoActivityThings(data);
            // }
            //check deadline
            task.IsDone = true;
            var temp = Tasks.FirstOrDefault(t => t.Id == task.Id);
            if (temp is null)
            {
                throw new NullReferenceException(nameof(temp));
            }
            temp.IsDone = true;
            if (Histories is null)
            {
                Histories = new List<ActivityLog>();
            }
            Histories.Add(new ActivityLog
            {
                Activity = temp.Activity,
                IsCompleted = true,
                User = ""
            });
            if (autoadvancetonextstate)
            {
                TryTransitToNextState();
            }
        }

        public void TryTransitToNextState()
        {
            bool completed = true;
            foreach (var activity in CurrentState.Activities)
            {
                if (activity.IsRequired == false)
                {
                    continue;
                }
                var task = Tasks.FirstOrDefault(e => e.IsDone == true && e.Activity.Name == activity.Name);
                if (task is null)
                {
                    completed = false;
                }
            }
            if (completed)
            {
                Transit(CurrentState.Name);
            }
            //throw new Exception("you must complete all tasks before moving to the next state");
        }



        public Node MoveNode(string action, string source, string role, string activity, string approver, List<DataCreateModel> data, bool doactivity = false)
        {
            var task = Tasks.FirstOrDefault(t => t.Activity.Name.ToLower() == activity.ToLower());
            if (task is null)
            {
                throw new NullReferenceException(nameof(task));
            }
            CompleteTask(task);
            if (source != CurrentNode.Name)
            {
                throw new Exception($"input state not match current state {CurrentNode.Name}");
            }
            List<string> incompleted = new List<string>();
            foreach (var item in CurrentNode.Activities)
            {
                if (!item.IsRequired)
                {
                    continue;
                }
                if (action == "approve")
                {
                    if (Histories.FirstOrDefault(e => e.Activity.Name.Equals(item.Name) && e.IsCompleted == true) is null)
                    {
                        incompleted.Add(item.Name);

                    }
                }
            }
            if (incompleted.Count > 0)
            {
                throw new Exception($"you must complete all activities [{string.Join(", ", incompleted)}] before submit this action");
            }
            if (doactivity)
            {
                var new_activity = CurrentNode.Activities.FirstOrDefault(s => s.Name == activity);
                if (new_activity is null)
                {
                    throw new NullReferenceException(nameof(new_activity));
                }
                if (new_activity.ActivityType == ActivityType.Absent)
                {
                    ((TLActivityOperator)new_activity).ApproverName = approver;

                }
                foreach (var item in data)
                {
                    var new_data = Data.FirstOrDefault(d => d.Id == item.Id);
                    if (new_data is null)
                    {
                        continue;
                    }
                    new_activity.DoActivityThings(new_data);
                }
            }
            // if (CurrentState.StateType == StateType.end)
            // {
            //     throw new InvalidOperationException("Request completed");
            // }
            if (Process.Nodes.FirstOrDefault(s => s.Name == source).IsLeaf()) {
                // if (action is "approve")
                // {
                //     return Process.Nodes.FirstOrDefault(s => s.Name == source);

                // }
                throw new InvalidOperationException("process is completed");
            }
            return CurrentNode = Process.NodeTransitFrom(source, action, role);
        }

        public void NodeTransit(string currentnode)
        {
            var node = Process.Nodes.FirstOrDefault(s => s.Name == currentnode);
            if (node is null)
            {
                throw new NullReferenceException(nameof(node));
            }
            List<string> incompleted = new List<string>();
            foreach (var item in CurrentNode.Activities)
            {
                if (!item.IsRequired)
                {
                    continue;
                }
                if (Histories.FirstOrDefault(e => e.Activity.Name.Equals(item.Name) && e.IsCompleted == true) is null)
                {
                    incompleted.Add(item.Name);
                }
            }
            if (incompleted.Count > 0)
            {
                throw new Exception($"you must complete all activities [{string.Join(", ", incompleted)}] before submit this action");
            }
            if (CurrentState.StateType == StateType.end)
            {
                return;
            }
            CurrentNode = Process.NodeTransitFrom(node.Name);
        }

        public List<Models.Action> NodeGetAvailableActions(string currentnode)
        {
            return Process.NodeGetAvailableActions(currentnode);
        }

        public List<Task> NodeGetTasks(Node node)
        {
            List<Task> tasks = new List<Task>();
            foreach (var activity in node.Activities)
            {
                foreach (var task in Tasks)
                {
                    if (!task.IsDone && task.Activity.Name == activity.Name)
                    {
                        tasks.Add(task);
                    }
                }
            }
            return tasks;
        }

        public List<Activity> NodeGetActivities(Node node)
        {
            if (node is null)
            {
                throw new NullReferenceException($"node cannot be null");
            }
            return Process.NodeGetActivities(node);
        }

        public static Model.Request NodeCreateFlow(RequestCreateModel model1, Process process)
        {
            if (model1 is null)
            {
                return null;
            }
            if (model1.Process is null)
            {
                return null;
            }

            process.Actions = new List<Models.Action>();
            process.States = new List<State>();
            process.Rules = new List<TransitionRule>();
            process.Roles = new List<Role>();
            process.Activities = new List<Activity>();
            process.Nodes = new List<Node>();

            foreach (var node in model1.Process.Nodes)
            {
                Node new_node = new Node
                {
                    Level = node.Level,
                    Name = node.Name,
                    Description = node.Description,
                    Activities = new List<Activity>(),
                    Iscompleted = node.Iscompleted,
                    Roles = new List<Role>(),
                    Actions = new List<Models.Action>(),
                    Childs = new List<Node>()
                };
                if (node.Actions != null) {
                    foreach (var action in node.Actions)
                    {
                        var new_action = new Models.Action {
                            Name = action.Name,
                            Description = action.Description
                        };
                        new_node.Actions.Add(new_action);
                        process.Actions.Add(new_action);
                    }

                }
                foreach (var activity in node.Activities)
                {
                    if (activity.ActivityType == ActivityType.Email)
                    {
                        Activity new_activity = new EmailActivityOperator
                        {
                            ActivityType = activity.ActivityType,
                            Name = activity.Name,
                            Description = activity.Description,
                            Duration = activity.Duration,
                            IsRequired = activity.IsRequired,
                            Discriminator = "EMAIL",
                            Roles = new List<Role>(),
                            Data = new List<Data>()
                        };
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role new_role = new Role
                                {
                                    Name = role.Name
                                };
                                process.Roles.Add(new_role);
                                new_activity.Roles.Add(new_role);
                                new_node.Roles.Add(new_role);
                            }
                            process.Activities.Add(new_activity);
                            new_node.Activities.Add(new_activity);

                        }
                    }
                    else if (activity.ActivityType == ActivityType.Absent)
                    {
                        Activity new_activity = new TLActivityOperator
                        {
                            ActivityType = activity.ActivityType,
                            Name = activity.Name,
                            Description = activity.Description,
                            Duration = activity.Duration,
                            IsRequired = activity.IsRequired,
                            Discriminator = "TALENT-LEAVE",
                            Roles = new List<Role>(),
                            Data = new List<Data>(),
                            AbsentName = activity.AbsentName,
                            ApproverName = activity.ApproverName,
                            DayOff = activity.DayOff,
                            IsReallyNotApproved = activity.IsReallyNotApproved,
                            Reason = activity.Reason
                        };
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role new_role = new Role
                                {
                                    Name = role.Name
                                };
                                process.Roles.Add(new_role);
                                new_activity.Roles.Add(new_role);
                                new_node.Roles.Add(new_role);
                            }
                            process.Activities.Add(new_activity);
                            new_node.Activities.Add(new_activity);

                        }

                    }
                    else if (activity.ActivityType == ActivityType.Generic)
                    {
                        Activity new_activity = new GenericActivityOperator
                        {
                            ActivityType = activity.ActivityType,
                            Name = activity.Name,
                            Description = activity.Description,
                            Duration = activity.Duration,
                            IsRequired = activity.IsRequired,
                            Roles = new List<Role>(),
                            Data = new List<Data>(),

                        };
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role new_role = new Role
                                {
                                    Name = role.Name
                                };
                                process.Roles.Add(new_role);
                                new_activity.Roles.Add(new_role);
                                new_node.Roles.Add(new_role);
                            }
                            process.Activities.Add(new_activity);
                            new_node.Activities.Add(new_activity);

                        }

                    }
                    else if (activity.ActivityType == ActivityType.Campaign)
                    {
                        Activity new_activity = new CampaignActivityOperator
                        {
                            ActivityType = activity.ActivityType,
                            Name = activity.Name,
                            Description = activity.Description,
                            Duration = activity.Duration,
                            IsRequired = activity.IsRequired,
                            CampaignName = activity.CampaignName,
                            Subscribers = new List<Contact>(),
                            IsRunning = activity.IsRunning,
                            Roles = new List<Role>(),
                            Data = new List<Data>(),
                            Discriminator = "CAMPAIGN"
                        };
                        // if (activity.Subscribers != null) 
                        // {
                        //     foreach (var item in activity.Subscribers)
                        //     {
                        //         ((CampaignActivityOperator)new_activity).Subscribers.Add(new Contact {
                        //             FullName = item.FullName,
                        //             Email = item.Email,
                        //             PhoneNumber = item.PhoneNumber,
                        //             Age = item.Age,
                        //             DataType = DataType.Contact
                        //         })
                        //     }
                        // }
                        if (activity.Roles != null)
                        {
                            foreach (var role in activity.Roles)
                            {
                                Role new_role = new Role
                                {
                                    Name = role.Name
                                };
                                process.Roles.Add(new_role);
                                new_activity.Roles.Add(new_role);
                                new_node.Roles.Add(new_role);
                            }
                            process.Activities.Add(new_activity);
                            new_node.Activities.Add(new_activity);

                        }

                    }
                }
                process.Nodes.Add(new_node);
            }
            
            if (model1.Process.Rules != null)
            {
                foreach (var rule in model1.Process.Rules)
                {
                    TransitionRule new_rule = new TransitionRule
                    {
                        CurrentNode = process.Nodes.FirstOrDefault(s => s.Name == rule.CurrentNode.Name),
                        NextNode = process.Nodes.FirstOrDefault(s => s.Name == rule.NextNode.Name),
                        Action = process.Actions.FirstOrDefault(a => a.Name == rule.Action.Name)
                    };
                    process.Rules.Add(new_rule);
                }

            }
            var new_request = new Model.Request
            {
                Title = model1.Title,
                UserId = model1.UserId,
                UserName = model1.UserName,
                CurrentNode = process.Nodes.FirstOrDefault(s => s.Level == 0),
                DateRequested = model1.DateRequested,
                Histories = new List<ActivityLog>(),
                Tasks = new List<Model.Task>(),
                Data = new List<Data>()
            };

            new_request.Process = process;
            new_request.Tasks = new List<Model.Task>();
            foreach (var activity in process.Activities)
            {
                new_request.Tasks.Add(new Model.Task
                {
                    Activity = activity,
                    IsDone = false
                });
            }

            return new_request;
        }

        public void NodeTryTransitToNextState()
        {
            bool completed = true;
            foreach (var activity in CurrentState.Activities)
            {
                if (activity.IsRequired == false)
                {
                    continue;
                }
                var task = Tasks.FirstOrDefault(e => e.IsDone == true && e.Activity.Name == activity.Name);
                if (task is null)
                {
                    completed = false;
                }
            }
            if (completed)
            {
                Transit(CurrentState.Name);
            }
            //throw new Exception("you must complete all tasks before moving to the next state");
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public Activity Activity { get; set; }
        public bool IsDone { get; set; }
        public DateTime Start { get; set; }
        public DateTime DeadLine { get; set; }
        public string UserRole { get; set; }
        public Request Request { get; set; }
        public int RequestId { get; set; }
    }

    

    public enum DataType
    {
        Documents = 0,
        Contact = 8,
        Photo = 1,
        Video = 2,
        Others = 3,
        Email = 4,
        Comment = 5,
        TalentLeave = 6,
        Campaign = 7
    }
}
