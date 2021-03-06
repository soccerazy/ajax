﻿using System;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Collections.Generic;

namespace ajax
{
public partial class user_page : Page
{
   [WebMethod] public static void void_noparam() {
      var a = "a";
   }
   [WebMethod] public static void void_param_as_list_of_users(string users) {
      var usrs = new JavaScriptSerializer().Deserialize<List<user>>(users);
      var name = usrs.Count > 0;
   }
   [WebMethod] public static void void_param_as_user(string user) {
      var usr = new JavaScriptSerializer().Deserialize<user>(user);
      var name = usr.name;
   }
   [WebMethod] public static void void_error() {
      throw new Exception("uh oh");
   }

   // JSON.parse requires double quotes
   [WebMethod] public static string json_noparam() {
      return "{\"name\":\"you\"}";
   }

   [WebMethod] public static string json_param(string user) {
      var usr = new JavaScriptSerializer().Deserialize<user>(user);
      return "{\"name\":\"" + usr.name + "\"}";
   }

   public class user
   {
      public string name { get; set; }
   }
}
}