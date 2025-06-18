<h1 align="center">🔍 Investigation_Game</h1>

---

## 🎯 תקציר

<div dir="rtl" align="right">

משחק חקירה המדמה תהליך הצמדת סנסורים לסוכנים בעלי חולשות שונות, ובדיקת ההתאמה ביניהם. הפרויקט כתוב ב־C# ומדגים עקרונות ירושה, פולימורפיזם, עבודה עם רשימות, מילונים ואינטרקציה מהקונסול.

---

## 🏗️ קלאסים עיקריים

### 🕵️‍♂️ Agent (מחלקת בסיס לסוכן)
- שדות עיקריים: Name, Rank, NumOfWeaknesses, Weaknesses[], מילון חולשות, מילון ניסיונות חקירה.
- פעולות עיקריות:
  - קבלת כמות חולשות לפי דרגת הסוכן.
  - יצירת חולשות אקראיות.
  - הפיכת מערך החולשות למילון (עבור השוואה).
  - השוואת חולשות שהודבקו בפועל לאלו שנדרשו.
  - הדפסת חולשות.
  - **לסוכנים בכירים (SeniorAgent, CompanyCommander): מנגנון תגובה אחרי מספר נסיונות כושלים.**

</div>

```csharp
public abstract class Agent
{
    public string Name { get; set; }
    public string Rank { get; set; }
    public int NumOfWeaknesses { get; set; }
    public string[] Weaknesses { get; protected set; }
    ...
    public void GetNumOfWeaknesses();
    public void GetRandomWeakness();
    public void ArrToDictionary();
    public bool CompareWeaknessDictionaries();
    public void PrintWeaknesses();
}
```

<div dir="rtl" align="right">

- מחלקות יורשות: JuniorAgent, SquadLeader, CompanyCommander, SeniorAgent.

---

### 🛰️ Sensor (מחלקת בסיס לסנסור)

- שדות עיקריים: Name.
- פעולה עיקרית: Activate — בדיקת התאמת הסנסור לסוכן.

</div>

```csharp
public abstract class Sensor
{
    public string Name { get; }
    public Sensor(string name);
    public abstract bool Activate(Agent agent);
}
```

<div dir="rtl" align="right">

- סנסורים נגזרים: MotionSensor, ThermalSensor, CellularSensor.

---

### 📝 InvestigationManager (ניהול החקירה)

- אחראי לניהול רשימות סוכנים וסנסורים.
- מתודות עזר: הוספת סוכן/סנסור, התחלת חקירה, קבלת קלט, ביצוע התאמות והשוואות.

</div>

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

## 🖥️ מהלך המשחק/תפריט

1. המשתמש בוחר סוכן מתוך רשימה.
2. בוחר סנסורים להצמדה לסוכן.
3. מוצגת כמות חולשות תואמות (בהתאם למציאות).
4. ניהול תהליך השוואה ועדכון התקדמות עד סיום כל הסוכנים.
5. **במקרה של סוכנים בכירים – אם השחקן נכשל מספר פעמים, הסוכן מגיב ומחזיר את השחקן שלב אחורה!**

---

## ⚙️ תצורת זרימה

1. הגדרת כל הסוכנים וכל סוגי הסנסורים.
2. לכל סוכן נוצרת רשימת חולשות אקראיות (בהתאם לדרגה).
3. המשתמש מצמיד סנסורים לסוכן.
4. מתבצעת השוואה בין החולשות שנדרשו לאלו שנבחרו.
5. במידה ויש הצלחה, עוברים לסוכן הבא; אחרת מוצגת כמות החולשות הנכונות שנבחרו.
6. **אם מדובר בסוכן בכיר (SeniorAgent/CompanyCommander) והיו מספר נסיונות כושלים, השחקן מוחזר שלב אחורה וצריך להתחיל מחדש את הסוכן הקודם!**
7. התהליך חוזר עד לסיום כל הסוכנים.

---

## ⚡ התנהגות מיוחדת: סוכנים בכירים

- לסוכנים בדרגות SeniorAgent ו-CompanyCommander יש "מנגנון הגנה":  
  אם השחקן טועה/נכשל במספר הצמדות רצופות (לפי כללים או מונה פנימי בקוד), הסוכן מגיב – לדוג' עלול "להיזהר" או "לברוח" – והשחקן מוחזר שלב אחד אחורה (לסוכן הקודם).
- כך המשחק מאתגר יותר ודורש מהשחקן דיוק וזהירות מול סוכנים בכירים!

---

## 🚀 הפעלה מהירה

1. יש להפעיל את הקוד דרך Visual Studio או ע"י `dotnet run`.
2. עקוב אחרי ההוראות בקונסול, בחר סוכן וסנסורים, ונהל את החקירה.

---

## 👤 קרדיטים

פיתוח: HershyRozenfeld

---
