﻿using System;
using System.Runtime.Serialization;

public class PermissionService : ValObject
{
    private String _description;

    [DataMember(Name = "Description")]
    public String Description
    {
        get { return _description; }
        set { _description = value; }
    }
}