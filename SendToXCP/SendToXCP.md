
  ![FanapPlus Logo](https://user-images.githubusercontent.com/32090767/46914639-244b3300-cfad-11e8-95ca-8e574ceb31fb.png)



<h1 lang="fa" dir="rtl" align="right">ارسال پیام دریافتی ازکاربر به اکسترنال CP</h1>
<p lang="fa" dir="rtl" align="right">برای دریافت پیام کاربر، باید یک POST API بر روی پروتکل htpp وجود داشته باشد. این آدرس Api باید توسط یک <a href="https://ticket.fanap.plus/portal">تیکت</a> در اختیار شرکت فناپ پلاس قرار بگیرد.<br/>
پس ازدریافت پیام کاربر  ,سامانه پیام رسان فناپ پلاس, اطلاعات زیر را در اختیار  شرکت مشتری قرار می دهد.</p>

<h2 lang="fa" dir="rtl" align="right">Http request body</h2>
<p lang="fa" dir="rtl" align="right">بدنه پیام دارای object ی به فرمت آرایه ای تک عضوی از پارامترهای زیر است:</p>
<table align="right" style="width:100%" dir="ltr">  
<tr><th>توضیحات</th><th>نام پارامتر</th></tr>  
<tr>
<td><p lang="fa" dir="rtl" align="right">شناسه منحصر به فردی که توسط پیام رسان فناپ پلاس به پیام اختصاص داده شده است</td>
<td>Muid</td>
</tr>
<tr>
<td><p lang="fa" dir="rtl" align="right">زمان دریافت پیام توسط سامانه؛ <br/><a href="https://ticket.fanap.plus/portal">Iso 8601</a>؛ universal time به فرمت:  <br/> "yyyy-MM-ddTHH:mm:ss.fffZ"</td>
<td>ReceiveTime</td>
</tr> 
<tr>
<td><p lang="fa" dir="rtl" align="right">شناسه کاربر</td>
<td>AccountId</td>
</tr>
<tr>
<td><p lang="fa" dir="rtl" align="right">درگاهی که پیام کاربر از آن دریافت شده است، شامل مقادیر:<br/>Pardis،<br/> Imi،<br/> Mtn،<br/> Rightel،<br/> Magfa<br/>است.</td><td>ChannelType</td>
</tr>
<tr><td><p lang="fa" dir="rtl" align="right">سرشماره ای که پیام کاربر از آن دریافت شده است.</td><td>Channel</td>
</tr>
<tr>
<td><p lang="fa" dir="rtl" align="right">عامل پیام دریافتی که دارای مقادیر:<br/>Sms،<br/>Cp،<br/>Tajmi،<br/>Ussd،<br/>Operator،<br/>Hamrahman<br/>است.
</td><td>Actor</td>
</tr>
<tr>  
<td><p lang="fa" dir="rtl" align="right">نوع پیام دریافتی که دارای مقادیر:<br/>Content،<br/>Subscription،<br/>Unsubscription،<br/>PremiumContent،<br/>SubscriptionQueryResult<br/>است.</td>  
<td>MessageType</td>
</tr>
<tr>  
<td><p lang="fa" dir="rtl" align="right">متن پیام ارسال شده توسط کاربر</td>  
<td>Content</td>  
</tr>
<tr>  
<td><p lang="fa" dir="rtl" align="right">شناسه منحصر به فرد مشتری که توسط شرکت فناپ پلاس در اختیار مشتری قرار گرفته و به منظور شناسایی مشتری از آن استفاده میکند.</td>  
<td>Sid</td>  
</tr>
<tr>  
<td><p lang="fa" dir="rtl" align="right">پیام امضا شده توسط شرکت فناپ پلاس.</td>  
<td>Muid</td>  
</tr>
</table>

<p lang="fa" dir="rtl" align="right" style="display:block;"><br/>در صورتی که متقاضی دریافت شماره کاربر هستندinput،  مقادیر زیر نیز ارسال می گردد:</p>

<table align="right" style="width:100%" dir="rtl">  
<tr><th>توضیحات</th><th>نام پارامتر</th></tr>  
<tr>
<td><p lang="fa" dir="rtl" align="right">شماره تلفن کاربر</td>
<td>UserPhoneNumber</td>
</tr>
</table>


<h2 lang="fa" dir="rtl" align="right"><br/><br/><br/><br/>مثال</h2>
<pre><code>[
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
]</​code></​pre>
