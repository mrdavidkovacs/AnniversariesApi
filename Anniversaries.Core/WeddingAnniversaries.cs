using System.Collections.Generic;

namespace Anniversaries.Core
{
    public class WeddingAnniversaries : IAnniversaryRepository
    {
        public IEnumerable<Anniversary> Get()
        {
            yield return new Anniversary("Grüne Hochzeit", 0m, "Tag der Trauung");
            yield return new Anniversary("Bier Hochzeit (9 Monate)", 0.75m, "Traditionell wird die Bierhochzeit nur dann gefeiert, wenn die Frau nach neun Monaten noch nicht schwanger ist, denn der Bierkonsum soll die Fruchtbarkeit erhöhen; allerdings nur, wenn das Bier in Maßen genossen wird. (https://de.wikipedia.org/wiki/Bierhochzeit)");
            yield return new Anniversary("Papier-Hochzeit (1 Jahr)", 1m, "Die Partnerschaft ist noch papierdünn.");
            yield return new Anniversary("Baumwoll-Hochzeit (2 Jahre)", 2m, "Die Verbindung wurde bereits kräftiger. Man schenkt Praktisches (z.B. ein baumwollenes Tuch).");
            yield return new Anniversary("Leder-Hochzeit (3 Jahre)", 3m, "Zäh wie Leder, so soll die Ehe halten.");
            yield return new Anniversary("Leinen-Hochzeit (4 Jahre)", 4m, "Das kritische 4. Jahr wird mit empfindlichem Stoff verglichen.");
            yield return new Anniversary("Holz-Hochzeit (5 Jahre)", 5m, "Die Ehe scheint Bestand zu haben, sie gibt nun Wärme und macht behaglich. Man schenkt Beständiges (z.B. Holzgeschnitztes).");
            yield return new Anniversary("Zucker-Hochzeit (6 Jahre)", 6m, "Eine gute Partnerschaft macht das Leben süß.");
            yield return new Anniversary("Zinn-Hochzeit (6,5 Jahre)", 6.5m, "Die Ehe sollte von Zeit zu Zeit wieder aufpoliert werden.");
            yield return new Anniversary("Kupfer-Hochzeit (7 Jahre)", 7m, "Die scheint so beständig zu sein, dass sie Patina anzusetzen verspricht. Man schenkt Kupferpfennige als Unterpfand des Glücks.");
            yield return new Anniversary("Bronze-Hochzeit (8 Jahre)", 8m, "Die Ehe hat ihren alltäglichen und nutzbringenden Weg gefunden. Beliebtes Geschenk sind Kuchenformen.");
            yield return new Anniversary("Keramik-Hochzeit (9 Jahre)", 9m, "Der weiche Ton ist im Ehe-Ofen gehärtet und farbig geworden.");
            yield return new Anniversary("Rosen-Hochzeit (10 Jahre)", 10m, "Die Blumen der Liebe kennzeichnen den ersten runden Jubeltag. Es ist schon ein Fest mit Gästen.");
            yield return new Anniversary("Stahl-Hochzeit (11 Jahre)", 11m, "Die Treue zueinander ist nun hart wie Stahl.");
            yield return new Anniversary("Seiden-Hochzeit (12 Jahre)", 12m, "Ein kräftiges, unzerreißbares Gewebe verbindet.");
            yield return new Anniversary("Petersilien-Hochzeit (12,5 Jahre)", 12.5m, "Die Ehe soll grün und würzig bleiben. Gäste bringen mit, was an diesem Tag Schmackhaftes verzehrt werden soll.");
            yield return new Anniversary("Maiglöckchen-Hochzeit (13 Jahre)", 13m, "Die Ehe ist wie kostbare geklöppelte oder gehäkelte Textilien.");
            yield return new Anniversary("Elfenbein-Hochzeit (14 Jahre)", 14m, "Die Ehe ist hart wie die Stoßzähne eines Elefanten.");
            yield return new Anniversary("Glas-Hochzeit (15 Jahre)", 15m, "Durchsichtig und klar sehen einander die Partnerin/der Partner. Als Geschenk bieten sich Gläser und Kristall an, denn einiges davon mag in der Ehe bereits in Scherben gegangen sein.");
            yield return new Anniversary("Porzellan-Hochzeit (20 Jahre)", 20m, "Fest, glänzend und zugleich empfindlich ist die Ehe geworden. Neues Geschirr kann eingeweiht werden.");
            yield return new Anniversary("Silberne-Hochzeit (25 Jahre)", 25m, "Ein Vierteljahrhundert hat bleibende Werte geschaffen. Das Jubelpaar trägt Silberkranz und Silbersträußchen beim Fest.");
            yield return new Anniversary("Perlen-Hochzeit (30 Jahre)", 30m, "Die Ehejahre reihen sich aneinander wie die Perlen einer Kette. Es ist Gelegenheit, der Ehefrau eine Perlenkette zu schenken.");
            yield return new Anniversary("Leinwand-Hochzeit (35 Jahre)", 35m, "Wie gute Leinwand hat sich die Ehe als unzerreißbar erwiesen. Manches ist bereits aufgebraucht – der Wäscheschrank muss neu aufgefüllt werden.");
            yield return new Anniversary("Aluminium-Hochzeit (37,5 Jahre)", 37.5m, "Die Ehe und das Glück waren dauerhaft. Als Geschenk ist all das geeignet, was mit Erinnerungen zu tun hat.");
            yield return new Anniversary("Rubin-Hochzeit (40 Jahre)", 40m, "Das Feuer der Liebe hält und trägt immer noch. Der Ehering bekommt mit dem Rubin den Edelstein der Liebe und des Feuers.");
            yield return new Anniversary("Goldene Hochzeit (50 Jahre)", 50m, "Wie Gold hat die Ehe allem standgehalten und sich als fest und kostbar erwiesen. Manche Ehepaare wechseln neue Ringe.");
            yield return new Anniversary("Diamantene Hochzeit (60 Jahre)", 60m, "Nichts kann die Ehe mehr angreifen. Die Partnerschaft ist unzerstörbar wie der wertvollste Edelstein.");
            yield return new Anniversary("Eiserne Hochzeit (65 Jahre)", 65m, "Eiserne Bande überstehen auch die stärksten Stürme.");
            yield return new Anniversary("Steinerne Hochzeit (67,5 Jahre)", 67.5m, "Hart wie Fels ist die Verbindung der Eheleute.");
            yield return new Anniversary("Gnaden-Hochzeit (70 Jahre)", 70m, "Gottes Gnade und Güte zeigt sich im langen, gemeinsamen Leben.");
            yield return new Anniversary("Juwelen-Hochzeit (72,5 Jahre)", 72.5m, "Wertvoll und unzerstörbar ist die Verbindung der Eheleute.");
            yield return new Anniversary("Kronjuwelen-Hochzeit (75 Jahre)", 75m, "Der Ehe werden die kostbarsten Edelsteine aufgesetzt.");
        }
    }
}