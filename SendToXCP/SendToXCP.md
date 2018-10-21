

  ![FanapPlus Logo](https://user-images.githubusercontent.com/32090767/46914639-244b3300-cfad-11e8-95ca-8e574ceb31fb.png)



<h1 lang="fa" dir="rtl" align="right">ارسال پیام دریافتی ازکاربر به اکسترنال CP</h1>
<p lang="fa" dir="rtl" align="right">برای دریافت پیام کاربر، باید یک POST API بر روی پروتکل http وجود داشته باشد. این آدرس Api باید توسط یک <a href="https://ticket.fanap.plus/portal">تیکت</a> در اختیار شرکت فناپ پلاس قرار بگیرد.<br/>
پس ازدریافت پیام کاربر  ,سامانه پیام رسان فناپ پلاس, اطلاعات زیر را در اختیار  شرکت مشتری قرار می دهد.</p>

<h2 lang="fa" dir="rtl" align="right">Http request body</h2>
<p lang="fa" dir="rtl" align="right">بدنه پیام دارای object ی به فرمت آرایه ای تک عضوی از پارامترهای زیر است:</p>
<div style="width: 50%">
<table align="left" style="max-width:50%">  
<tr>
<th>Parameter Name</th><th>Description</th></tr>  
<tr>
<td>Muid</td>
<td><p lang="fa" dir="rtl" align="right">شناسه منحصر به فردی که توسط پیام رسان فناپ پلاس به پیام اختصاص داده شده است</td>
</tr>
<tr>
<td>ReceiveTime</td>
<td><p lang="fa" dir="rtl" align="right">زمان دریافت پیام توسط سامانه؛
 <br/><a href="https://ticket.fanap.plus/portal">Iso 8601</a>؛ universal time به فرمت:  
 <br/> "yyyy-MM-ddTHH:mm:ss.fffZ"</td>
</tr> 
<tr>
<td>AccountId</td>
<td><p lang="fa" dir="rtl" align="right">شناسه کاربر</td>
</tr>
<tr>
<td>ChannelType</td>
<td><p lang="fa" dir="rtl" align="right">درگاهی که پیام کاربر از آن دریافت شده است، شامل مقادیر:
<br/>Pardis،
<br/> Imi،
<br/> Mtn،
<br/> Rightel،
<br/> Magfa
<br/>است.
</td>
</tr>
<tr>
<td>Channel</td>
<td><p lang="fa" dir="rtl" align="right">سرشماره ای که پیام کاربر از آن دریافت شده است.</td>
</tr>
<tr>
<td>Actor</td>
<td><p lang="fa" dir="rtl" align="right">عامل پیام دریافتی که دارای مقادیر:<br/>Sms،
<br/>Cp،
<br/>Tajmi،
<br/>Ussd،
<br/>Operator،
<br/>Hamrahman
<br/>است.
</td>
</tr>
<tr>  
<td>MessageType</td>
<td><p lang="fa" dir="rtl" align="right">نوع پیام دریافتی که دارای مقادیر:<br/>Content،<br/>Subscription،<br/>Unsubscription،<br/>PremiumContent،<br/>SubscriptionQueryResult<br/>است.</td>  
</tr>
<tr>  
<td>Content</td>
<td><p lang="fa" dir="rtl" align="right">متن پیام ارسال شده توسط کاربر</td>    
</tr>
<tr>  
<td>Sid</td> 
<td><p lang="fa" dir="rtl" align="right">شناسه منحصر به فرد مشتری که توسط شرکت فناپ پلاس در اختیار مشتری قرار گرفته و به منظور شناسایی مشتری از آن استفاده میکند.</td>   
</tr>
<tr>  
<td>Signature</td>
<td><p lang="fa" dir="rtl" align="right">پیام امضا شده توسط شرکت فناپ پلاس</td>
</tr>
</table>
</div>

<br/><br/>
<p lang="fa" dir="rtl" align="right"><br/><b>در صورتی که متقاضی دریافت شماره کاربر هستندinput،  مقادیر زیر نیز ارسال می گردد:</p>
<table align="left" style="width:50%">  
<tr>
<th>Parameter Name</th><th>Description</th></tr>  
<tr>
<td><p lang="fa" dir="rtl" align="right">شماره تلفن کاربر</td>
<td>UserPhoneNumber</td>
</tr>
</table>


<h4 lang="fa" dir="rtl" align="right"><br/><br/><br/><br/>مثال</h4>

<pre><code class="prettyprint">
[
	{
		“Muid”: “74c925a6211f483fafb29650feb821c7”,
		“Sid”: ” d45987d89490432990f4af64ee2c3cd6”,
		“ReceiveTime”: "2018-04-23T10:22:21.028Z",
		“ChannelType”: “Imi”,
		“Channel”: “983048”,
		“Actor”: “Sms”,
		“AccountId”: “VL6DUI5T5TKUBJKGOSOB47P7XOUQ”,
		“UserPhoneNumber”: “98990***4656”,
		“MessageType”: “Content”,
		“Content”: “test”,
		Signature: LSrRlM9Jh8HA9C6WtOZHXiRd4jt24vpALJr4FFvhda4TA2A4MO+xYtm93bxUcI3LANHDd5fMs2ruRUqAadBxpDWRG+AVOLDR8uQHOyRNszvUYKdoDnnahRx6f3GI0abx6Lw1xUxzSUTr1Dk6PywllkVL2pmbaM6mL5PR+tBO2Ps=
	}
]
</pre></code>

<h2 lang="fa" dir="rtl" align="right">توضیحات فیلد ها</h2>
<h3 lang="fa" dir="rtl" align="right">MessageType : </h3>
<p lang="fa" dir="rtl" align="right">نوع پیام دریافتی دارای یکی از مقادیر زیر است :</p>

<div style="width: 50%">
<table align="left" style="width:100%">  
<tr>
<th>Parameter Value</th><th>Description</th></tr>  
<tr>
<td>Content</td>
<td><p lang="fa" dir="rtl" align="right">عادی</td>
</tr>
<tr>
<td>Subscription</td>
<td><p lang="fa" dir="rtl" align="right">عضویت</td>
</tr>
<tr>
<td>unSubscription</td>
<td><p lang="fa" dir="rtl" align="right">لغو عضویت</td>
</tr>
<tr>
<td>PremiumContent</td>
<td><p lang="fa" dir="rtl" align="right">پیام پولی</td>
</tr>
<tr>
<td>SubscriptionQueryResult</td>
<td><p lang="fa" dir="rtl" align="right">پاسخ بررسی عضویت کاربر</td>
</tr>
</table>
</div>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>

<h3 lang="fa" dir="rtl" align="right">Content : </h3>
<p lang="fa" dir="rtl" align="right"> در صورتی که نوع پیام دریافتی SubscriptionQueryResult باشد، محتوا، یک آبجکت JSON با پراپرتی های زیر است:</p>

<table align="left" style="width:100%">  
<tr>
<th>Parameter Value</th><th>Description</th></tr>  
<tr>
<td>Muid</td>
<td><p lang="fa" dir="rtl" align="right">شناسه پیام ارسالی بررسی عضویت کاربر</td>
</tr>
<tr>
<td>Result</td>
<td><p lang="fa" dir="rtl" align="right">نتیجه بررسی</td>
</tr>
</table>
<br>
<br>
<br>
<br>
<br>
<br><br><br>
<p lang="fa" dir="rtl" align="right">مقدار Result در صورتی که کاربر عضو سرویس باشد True و در صورتی که عضو نباشد False است.</p>
<h4 lang="fa" dir="rtl" align="right">مثال :</h4>

<pre><code class="prettyprint">
{"Muid":"1a3db98cf9b547a7a903e5b8c200824b","Result":"True"}
</pre></code>

<h3 lang="fa" dir="rtl" align="right">Actor: </h3>
<p lang="fa" dir="rtl" align="right">عامل پیام دریافتی دارای یکی از مقادیر زیر است :<br>
کلیه عملیات کاربر غیر از کانال اس ام اس نیز برای مشتری ارسال میشود .</p>

<table align="left" style="width:100%">  
<tr>
<th>Parameter Value</th><th>Description</th></tr>  
<tr>
<td>Sms</td>
<td><p lang="fa" dir="rtl" align="right">ارسال پیامک</td>
</tr>
<tr>
<td>Cp</td>
<td><p lang="fa" dir="rtl" align="right">درخواست مشتری</td>
</tr>
<tr>
<td>Tajmi</td>
<td><p lang="fa" dir="rtl" align="right">پنل تجمیعی</td>
</tr>
<tr>
<td>USSD</td>
<td><p lang="fa" dir="rtl" align="right">سامانه USSD</td>
</tr>
<tr>
<td>Operator</td>
<td><p lang="fa" dir="rtl" align="right">اپراتور</td>
</tr>
<tr>
<td>Hamrahman</td>
<td><p lang="fa" dir="rtl" align="right">همراه من</td>
</tr>
</table>
<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
<h4 lang="fa" dir="rtl" align="right">مثال :</h4>
<p lang="fa" dir="rtl" align="right"></p>
<ul lang="fa" dir="rtl" align="right">  
<li>عضویت بر روی سرویس از طریق اپ مشتری و ارسال OTP توسط کاربر:</li>  
<ul>
<li> Actor : CP</li>
<li>MessageType : Subscription</li>
</ul>
<li>لغو عضویت بر روی سرویس از طریق درخواست مشتری :</li>  
<ul>
<li> Actor : CP</li>
<li>MessageType : Unsubscription</li>
</ul><li>لغو عضویت کاربر از طریق پنل تجمیعی :</li>  
<ul>
<li> Actor : Tajmi</li>
<li>MessageType : Unsubscription</li>
</ul><li>لغو عضویت از طریق کال سنتر اپراتور :</li>  
<ul>
<li> Actor : Operator</li>
<li>MessageType : Unsubscription</li>
</ul>
</ul>
<h3 lang="fa" dir="rtl" align="right">Signature: </h3>
<p lang="fa" dir="rtl" align="right">برای احراز هویت و اثبات صحت پیام می­باشد. فناپ پلاس با توجه به پارامترهای بدنه­ ی پیام ، پیام فرمت شده ­ای را می­سازد که همان پیام را توسط کلید خصوصی خود امضا می­کند و در پارامتر Signature قرار می­دهد . شرکت خصوصی محتوای این پیام را با کلید عمومی فناپ پلاس واقع در <a href="https://github.com/appson/messaging-public/blob/master/Signature-PublicKey/publicKey.txt">این آدرس </a>رمزگشایی می­کند. </p>
<p lang="fa" dir="rtl" align="right">پیام فرمت شده بدین ترتیب ایجاد شده است  : <br>( توضیح آنکه، مقادیر داخل براکت با توجه به مقادیر پارامترهای نظیر در بدنه ی پیام به صورت جدا شده با ویرگول،   پر می شوند و ترتیب از چپ به راست حتما رعایت شود ):</p>

<code class="prettyprint">
[ReceiveTime],[Sid],[ChannelType],[Channel],[Muid],[Content],[MessageType],[AccountId]
</code>
<br><p lang="fa" dir="rtl" align="right"> شرکت فناپ پلاس منتظر پاسخ فراخوانی مشتری نمی ماند و در صورتی که مشتری قصد ارسال پیام به کاربر را دارد باید وب سرویس ارسال پیام به مشتری پیاده سازی شود و از طریق آن پیام ها ارسال شود. سرویس ارسال پیام به مشتری نیازمند یک کلید نامتقارن است که برای امضا و احراز هویت مشتری مورد استفاده قرار میگیرد، بنابراین کلید عمومی آن در فرمت XML باید در اختیار شرکت فناپ پلاس قرار بگیرد.</p><br>

<h2 lang="fa" dir="rtl" align="right">پیوست ۱</h2>
<p lang="fa" dir="rtl" align="right">نحوه  sign  کردن  فناپ پلاس  :</p>
<p lang="fa" dir="rtl" align="right">الگوریتم مورد استفاده برای  asymmetric cryptography  ، الگوریتم  RSA  است  که الگوریتم  hash  آن نیز  SHA1  است نمونه کد در زیر آمده است.</p><br>

<pre><code class="prettyprint">
public static string Sign(string key, string text)
{
	using (var rsaProvider = new RSACryptoServiceProvider(CspParams))
	{
		rsaProvider.FromXmlString(key);
		var plainBytes = Encoding.UTF8.GetBytes(text);
		var encryptedBytes = rsaProvider.SignData(plainBytes, new SHA1CryptoServiceProvider());
		return Convert.ToBase64String(encryptedBytes);
	}
}
</pre></code>

<h2 lang="fa" dir="rtl" align="right">پیوست ۲</h2>
<p lang="fa" dir="rtl" align="right">نمونه کد احراز هویت  :</p><br>

<pre><code class="prettyprint">
public static bool Check(string key, string signedText, string text)
{
	if (string.IsNullOrWhiteSpace(text)) return false;
	try
	{
		// Select target CSP
		var cspParams = new CspParameters { ProviderType = 1 };
		// PROV_RSA_FULL
		//cspParams.ProviderName; // CSP name
		var rsaProvider = new RSACryptoServiceProvider(cspParams);
		// Import private/public key pair
		rsaProvider.FromXmlString(key);
		var encryptedBytes = Convert.FromBase64String(signedText);
		var plainInput = Encoding.UTF8.GetBytes(text);
		// Decrypt text
		var check = rsaProvider.VerifyData(plainInput, new SHA1CryptoServiceProvider(), encryptedBytes);
		return check;
	}
	catch (Exception exception)
	{
		Log.Error(exception.Message, exception);
		return false;
	}
}
</pre></code>
