// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.EntityFrameworkCore;

// namespace HogeBlazor.Shared.Models;

// [Index(nameof(Email), IsUnique = true)]
// public class User
// {
//     private string _plainPassword = string.Empty;

//     /// <summary>
//     /// Usersテーブル内のキー情報
//     /// </summary>
//     /// <value></value>
//     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//     [Key]
//     public int Id { get; set; }

//     /// <summary>
//     /// ユーザーの表示名
//     /// </summary>
//     /// <value></value>
//     [Required(ErrorMessage = "{0}を入力する必要があります。")]
//     [StringLength(100, ErrorMessage = "{0}は文字数{1}以内である必要があります。")]
//     public string Name { get; set; } = string.Empty;

//     /// <summary>
//     /// メールアドレス
//     /// ログイン時のキー情報
//     /// </summary>
//     /// <value></value>
//     [Required(ErrorMessage = "{0}を入力する必要があります。")]
//     [EmailAddress]
//     [StringLength(100, ErrorMessage = "{0}は文字数{1}以内である必要があります。")]
//     public string Email { get; set; } = string.Empty;

//     /// <summary>
//     /// 平文のパスワード
//     /// </summary>
//     /// <value></value>
//     [NotMapped]
//     [Required(ErrorMessage = "{0}を入力する必要があります。")]
//     [StringLength(100, MinimumLength = 8, ErrorMessage = "{0}は文字数{2}から{1}の範囲内である必要があります。")]
//     public string PlainPassword
//     {
//         set
//         {
//             _plainPassword = value;
//             HashedPassword = hash(value);
//         }
//         get
//         {
//             return _plainPassword;
//         }
//     }

//     /// <summary>
//     /// ハッシュ化したパスワード
//     /// </summary>
//     /// <value></value>
//     public string HashedPassword { get; set; } = string.Empty;

//     /// <summary>
//     /// ロール
//     /// </summary>
//     /// <value></value>
//     [Required]
//     public RoleType Role { get; set; }

//     /// <summary>
//     /// レコード作成時刻
//     /// </summary>
//     /// <value></value>
//     [Required(ErrorMessage = "{0}を入力する必要があります。")]
//     [Column(TypeName = "Timestamp")]
//     public DateTime CreatedAt { get; set; }

//     /// <summary>
//     /// レコード更新時刻
//     /// </summary>
//     /// <value></value>
//     [Required(ErrorMessage = "{0}を入力する必要があります。")]
//     [Column(TypeName = "Timestamp")]
//     public DateTime UpdatedAt { get; set; }

//     /// <summary>
//     /// 論理削除フラグ
//     /// https://blog.beachside.dev/entry/2020/03/30/200000
//     /// </summary>
//     /// <value></value>
//     [Required(ErrorMessage = "{0}を入力する必要があります。")]
//     public bool IsDel { get; set; } = false;

//     /// <summary>
//     /// ロール列挙型
//     /// </summary>
//     public enum RoleType
//     {
//         Admin,
//         User,
//         Guest
//     }

//     // 独自のコンストラクタを作ってしまうと、EntityFrameworkがマイグレーションをする際にそれを使用してしまう。
//     // NotMappedなカラムを引数にできなくなるため、デフォルトコンストラクタを利用するよう独自のコンストラクタは削除した。
//     /// <summary>
//     /// コンストラクタ
//     /// </summary>
//     /// <param name="name">名前</param>
//     /// <param name="email">メールアドレス</param>
//     /// <param name="plainPassword">パスワード</param>
//     /// <param name="role">ロール</param>
//     // public User(string name, string email, string plainPassword, RoleType role)
//     // {
//     //     this.Name = name;
//     //     this.Email = email;
//     //     this.PlainPassword = plainPassword;
//     //     this.HashedPassword = hash(plainPassword);
//     //     this.Role = role;
//     // }

//     // public User(int id, string name, string email, RoleType role)
//     // {
//     //     this.Id = id;
//     //     this.Name = name;
//     //     this.Email = email;
//     //     this.Role = role;
//     // }

//     /// <summary>
//     /// ハッシュ関数
//     /// パスワードのハッシュ化に内部的に利用
//     /// </summary>
//     /// <param name="plain">平文文字列</param>
//     /// <returns>ハッシュ化した文字列</returns>
//     public static string hash(string plain)
//     {
//         return BCrypt.Net.BCrypt.HashPassword(plain, workFactor: 5);
//     }

//     public bool Authenticate(string plainPassword)
//     {
//         return BCrypt.Net.BCrypt.Verify(plainPassword, this.HashedPassword);
//     }

//     // public class PlainPasswordAttribute : ValidationAttribute
//     // {
//     //     public string GetErrorMessage()
//     //     {
//     //         return "Passwordは文字数8から100の範囲内である必要があります。";
//     //     }

//     //     protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//     //     {

//     //         return ValidationResult.Success;
//     //     }
//     // }
// }
