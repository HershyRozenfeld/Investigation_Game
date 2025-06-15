<h1 align="center">🔍 Investigation_Game</h1>

---

## קלאסים

<div align="right">

<ul>
  <li>
    <b>מחלקת בסיס של סוכן</b>:<br>
    <span style="color:gray;">ממנו ירשו מחלקות סוכן זוטר, מ"כ, מ"פ, בכיר.</span>
  </li>
  <li>
    <b>קלאס בסיס של סנסורים</b>:<br>
    <span style="color:gray;">ממנו ירשו סנסור תנועה, סנסור תרמי, סנסור סלולרי.</span>
  </li>
  <li>
    <b>קלאס ניהול חקירה</b>:<br>
    <span style="color:gray;">בו יתבצעו הבדיקות</span>
  </li>
</ul>

</div>

---

### <span style="font-size:1.1em;">מאפיינים</span>

- לכל סוכן יש <b>חולשות</b> שהם בעצם סנסורים שמסוגלים להשפיע אליו.
- בניהול החקירה ניצור <b>רשימה של סנסורים</b> להצמדה לסוכן.
- לכל סנסור מתודה <code>Activate</code> שתחזיר כמה סנסורים תואמים למערך החולשות של הסוכן.

---

### 🖥️ ממשק תפריט

- בחירת חדר מסוים
- בחירת שני סנסורים (נקודת התחלה)
- הצגת כמות חולשות תואמות לסוכן

---

### 🔄 תצורת הזרימה

<details>
<summary>לחץ לצפייה</summary>

<div align="right">

- מערכת ניהול החקירה מכילה רשימת מופעי סוכנים ורשימת כל סוגי הסנסורים.
- הדפסת כל הסוכנים למשתמש.
- קבלת קלט מהמשתמש לבחירת סוכן ולבחירת סנסור להצמדה.
- יצירת מילון של הסנסורים שהוצמדו לסוכן (הסנסור כמפתח, הערך - הכמות).
- יצירת מילון נוסף מרשימת חולשות הסוכן.
- השוואה: אם המילונים זהים → הצלחה ומעבר לסוכן הבא, אחרת הצגת כמות בחירות נכונות.
- התהליך חוזר עד לסיום כל הסוכנים.

</div>

</details>


---

## 🗂️ מבנה הפרויקט

```text
Investigation_Game/
├── Agent.cs
├── JuniorAgent.cs
├── SquadLeader.cs
├── CompanyCommander.cs
├── SeniorAgent.cs
├── Sensor.cs
├── MotionSensor.cs
├── ThermalSensor.cs
├── CellularSensor.cs
├── InvestigationManager.cs
└── Program.cs
```

---

## 🏗️ קלאסים עיקריים

---

### 🕵️‍♂️ Agent (מחלקת בסיס לסוכן)
```csharp
public abstract class Agent
{
    public string Name { get; set; }
    public List<string> Weaknesses { get; protected set; }

    public Agent(string name);

    public abstract string GetRank();
}
```
- <b>מחלקות יורשות:</b>  
  <code>JuniorAgent</code>, <code>SquadLeader</code>, <code>CompanyCommander</code>, <code>SeniorAgent</code>  
  <span style="color:gray;">כל אחת מייצגת דרגת סוכן עם מאפיינים וחולשות ייחודיים.</span>

---

### 🛰️ Sensor (מחלקת בסיס לסנסור)
```csharp
public abstract class Sensor
{
    public string Name { get; }
    public Sensor(string name);

    public abstract bool Activate(Agent agent);
}
```
- <b>סוגי סנסורים:</b>  
  <code>MotionSensor</code>, <code>ThermalSensor</code>, <code>CellularSensor</code>  
  <span style="color:gray;">לכל סנסור יכולת לזהות חולשה מסוימת.</span>

---

### 📝 InvestigationManager (ניהול החקירה)
```csharp
public class InvestigationManager
{
    private List<Agent> agents;
    private List<Sensor> allSensors;

    public InvestigationManager();

    public void AddAgent(Agent agent);
    public void AddSensor(Sensor sensor);
    public void StartInvestigation();

    // מתודות עזר לבחירה, הצגה, והשוואת התאמות
}
```

---
