﻿namespace WorkPlaceProject.Application.StoryPointer
{
    public class StoryPointSelectionAdto
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public int SelectionValue { get; set; }
    }
}
