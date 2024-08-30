using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace PSL.Domain.Entities;

public class BaseEntity<T>
{
    public T Id { get; set; }

    public DateTime? CreateDate { get; set; }
    
    public DateTime? ModifyDate { get; set; }
    
    public DateTime? DeletedDate { get; set; }

    public bool IsDelete { get; set; } = false;
}