using System;
using System.Collections.Generic;

namespace DTS_Web_Api.Models;

public partial class TbMProfiling
{
    public string Id { get; set; } = null!;

    public int EducationId { get; set; }

    public virtual TbMEducation Education { get; set; } = null!;

    public virtual TbMEmployee IdNavigation { get; set; } = null!;
}
