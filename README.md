<h1>Sorry fish</h1>

<h2>1. Опис на апликацијата</h2>
<p><div align="justify">
Со оваа апликација ние направивме игра во која главната идеја е рибата да изеде што е можно повеќе зелени црви,  притоа избегнувајќи ги отровните црвени црви кои ги преполовуваат поените на играчот и ајкулите кои ја јадат рибата.
За пореален изглед на играта и непосакувано треперење на екранот искористивме DoubleBuffered.
</div></p>

<h2>2. Упатство за користење </h2>
<p><div align="justify">
Со самото стартување на апликацијата се појавува прозорец преку кој играчот мора да се најави со опцијата "Најави се" за да ја започне играта при клик на копчето "Играј". Следната опција која ја нуди овој прозорец е "Инструкции" преку која корисникот може да ги прочита правилата за играта пред да ја започне. Последната опција е "Ранг листа" во која се зачувуваат сите досегашни најавени корисници и нивните поени, кои се превземени од "базата" (baza.txt). Доколку корисникот се најави втор пат со истото име во ранг листата ќе бидат прикажани само неговите максимални освоени поени. Во горниот лев агол е поставена икона преку која корисникот може да го исклучи звукот на играта:
</div></p>

<p><div align="center"><img width="400" src="https://user-images.githubusercontent.com/18449614/173579845-ae97556c-3c5a-4976-9c5d-377f5b7273e7.png"> </div><div align="center"></div></p>

Откако корисникот ќе се најави и ќе ја одбере опцијата "Играј" играта започнува. На наредната слика е прикажан изгледот на играта:

<p><div align="center"><img width="300" src="https://user-images.githubusercontent.com/18449614/173580408-4169d6b1-84d1-4c54-8442-5fd2ee367c34.png" > </div><div align="center"></div></p>

<p><div align="justify">
 Корисникот може да ја придвижува рибата преку со стрелките од тастатурата, како и со W (нагоре), S (надолу), A (лево), D (десно), како и со комбинации од овие копчиња. Со комбинации на копчињата горе + лево,  горе + десно , доле + лево  и  доле + десно рибата се придвижува накосо.  Во долниот дел на екранот се прикажуваат моменталните поени на корисникот и соодветни пораки од типот "Бравоо!" (доколку рибата изеде зелен црв), "Внимавај! Поените се преполовени." (доколку рибата изеде црвен црв)  и "Повеќе среќа следниот пат!" (доколку ајкулата ја изеде рибата).  Откако ајкулата ќе ја изеде рибата, таа иронично извикува "ИЗВИНИ РИБО" од каде што се инспириравме за името на нашата апликација. Доколку корисникот сака да ја паузира играта тоа може да го направи преку  копчето Escape со што му се појавува дијалог прозорец кој го прашува дали сака да ја исклучи играта. Ако корисникот одобри неговиот резултат нема да биде зачуван во базата. Со текот на времето играта се забрзува и доаѓаат се помалку зелени, а се повеќе црвени црви и ајкули. Со тоа играта станува се потешка и шансите за преживување се помали. 
</div></p>

      
<h2>3. Податочна структура</h2>
<br>
Приказ на податоци и функции од класата Fish. За секоја променлива и функција има xml summary со детално објаснување.
<br>

```c#
public class Fish
{
/// <summary>
/// Локацијата на сликата
/// </summary>
public string ImageLocation { get; set; }
/// <summary>
/// Позицијата на рибата
/// </summary>
public Point Location { get; set; }
/// <summary>
/// Големината на рибата
/// </summary>
public static Size FishSize { get; set; }
/// <summary>
/// Конструктор
/// </summary>
/// <param name="location">локација на рибата</param>
/// <param name="fishSize">големина на рибата</param>
public Fish(Point location,Size fishSize)
{
this.Location = location;
FishSize = fishSize;
}
// Методи:
/// <summary>
/// Движење на рибата нагоре
/// </summary>
public void MoveUp()
{
if (Location.Y > 15)
Location = new Point(Location.X,Location.Y - 15);
}
/// <summary>
/// движење на рибата нагоре и надолу
/// </summary>
public void MoveUpLeft()
{
if (Location.Y > 15 && (Location.X > 15))
Location = new Point(Location.X + (int)(15 * Math.Cos(135 * (Math.PI / 180))),
Location.Y - (int)(15 * Math.Sin(135 * (Math.PI / 180))));
  }
}

```

