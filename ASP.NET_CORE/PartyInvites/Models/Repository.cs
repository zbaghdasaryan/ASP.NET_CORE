﻿using System.Collections.Generic;

namespace PartyInvites.Models
{
    public class Repository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();

        public static List<GuestResponse> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}
