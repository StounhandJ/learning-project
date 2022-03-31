package mpt.ru.mar.practic.ui.placeholder;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import mpt.ru.mar.practic.calc.BodyMassIndexActivity;
import mpt.ru.mar.practic.calc.CirculatorySkibinskiActivity;
import mpt.ru.mar.practic.calc.EnduranceCoefficientActivity;
import mpt.ru.mar.practic.calc.IndexFunctionalActivity;
import mpt.ru.mar.practic.calc.KerdoIndexActivity;
import mpt.ru.mar.practic.calc.LevelCardiovascularActivity;
import mpt.ru.mar.practic.calc.LifeIndexActivity;

/**
 * Helper class for providing sample content for user interfaces created by
 * Android template wizards.
 * <p>
 * TODO: Replace all uses of this class before publishing your app.
 */
public class PlaceholderContent {

    /**
     * An array of sample (placeholder) items.
     */
    public static final List<PlaceholderItem> ITEMS = new ArrayList<PlaceholderItem>();

    /**
     * A map of sample (placeholder) items, by ID.
     */
    public static final Map<String, PlaceholderItem> ITEM_MAP = new HashMap<String, PlaceholderItem>();

    private static final int COUNT = 25;

    static {
        addItem(new PlaceholderItem(
                "0",
                "Индекс массы тела (кг/м2)",
                "18.5-25",
                BodyMassIndexActivity.class,
                new double[]{
                        16.0, 18.5,
                        18.5, 25.0,
                        25.0, 30.0,
                        30.0, 35.0,
                        35.0, 40.0,
                        40.0, 999999.0
                },
                Arrays.asList(
                        "недостаток массы тела",
                        "норма",
                        "избыточная масса тела",
                        "первая степень ожирения",
                        "вторая степень ожирения",
                        "третья степень ожирения"
                )));

        addItem(new PlaceholderItem(
                "1",
                "Коэффициент выносливости",
                "16 усл. ед.",
                EnduranceCoefficientActivity.class,
                new double[]{
                        -99999.0, 16.0,
                        18.5, 25.0,
                        25.0, 30.0,
                        30.0, 35.0,
                        35.0, 40.0,
                        40.0, 999999.0
                },
                Arrays.asList(
                        "свидетельствует об усилении кардиореспираторной системы \n- увеличение указывает на ослабление деятельности сердечно-сосудистой системы или детренированности обследуемого \n- при занятиях спортом коэффициент выносливости может быть ниже 16 усл.ед., из-за укрепления сердечно-сосудистой системы, коэффициент выносливости коррелирует с уровнем физической работоспособности организма",
                        "норм"
                )));

        addItem(new PlaceholderItem(
                "2",
                "Уровень регуляции сердечно-сосудистой системы",
                "81-90",
                LevelCardiovascularActivity.class,
                new double[]{
                        -9999.0, 74.0,
                        75.0, 80.0,
                        81.0, 90.0,
                        91.0, 100.0,
                        101.0, 999999.0
                },
                Arrays.asList(
                        "высокий уровень регуляции сердечно-сосудистой системы",
                        "выше среднего",
                        "средний",
                        "ниже среднего",
                        "низкое значение регуляции"
                )));

        addItem(new PlaceholderItem(
                "3",
                "Жизненный индекс",
                "50-61 мл/кг",
                LifeIndexActivity.class,
                new double[]{
                        -9999.0, 50.0,
                        51.0, 61.0,
                        62.0, 999999.0
                },
                Arrays.asList(
                        "все плохо",
                        "норма",
                        "при большой жизненной емкости (ЖЕЛ) легкие лучше вентилируются и организм получает больше кислорода."
                )));

        addItem(new PlaceholderItem(
                "4",
                "Циркулярно-респираторный коэффициент Скибински",
                "10-30",
                CirculatorySkibinskiActivity.class,
                new double[]{
                        -9999.0, 5.0,
                        5.0, 10.0,
                        10.0, 30.0,
                        30.0, 60.0,
                        62.0, 999999.0
                },
                Arrays.asList(
                        "очень плохо",
                        "неудовлетворительно",
                        "хорошо",
                        "очень хорошо"
                )));

        addItem(new PlaceholderItem(
                "5",
                "Вегетативный индекс Кердо",
                "от -15 до +15",
                KerdoIndexActivity.class,
                new double[]{
                        -9999.0, -30.0,
                        -30.0, -16.0,
                        -15.0, 15.0,
                        16.0, 30.0,
                        31.0, 999999.0
                },
                Arrays.asList(
                        "выраженная парасимпатикотония",
                        "парасимпатикотония",
                        "уравновешенность симпатических и парасимпатических влияний",
                        "симпатикотония",
                        "выраженная симпатикотония"
                )));

        addItem(new PlaceholderItem(
                "6",
                "Индекс функциональных изменений",
                "2,6—3,09",
                IndexFunctionalActivity.class,
                new double[]{
                        -9999.0, 2.6,
                        2.6, 3.09,
                        3.09, 999999.0
                },
                Arrays.asList(
                        "функциональные возможности системы кровообращения хорошие.",
                        "неудовлетворитудовлетворительные функциональные возможности системы кровообращения с умеренным напряжением механизмов регуляцииельно",
                        "сниженные, недостаточные возможности системы кровообращения, наличие выраженных нарушений процессов адаптации. "
                )));

        addItem(new PlaceholderItem(
                "7",
                "",
                "",
                IndexFunctionalActivity.class));
    }

    private static void addItem(PlaceholderItem item) {
        ITEMS.add(item);
        ITEM_MAP.put(item.id, item);
    }

    private static String makeDetails(int position) {
        StringBuilder builder = new StringBuilder();
        builder.append("Details about Item: ").append(position);
        for (int i = 0; i < position; i++) {
            builder.append("\nMore details information here.");
        }
        return builder.toString();
    }

    /**
     * A placeholder item representing a piece of content.
     */
    public static class PlaceholderItem {
        public final String id;
        public final String title;
        public final String norm;
        public String result;
        public final Class<?> view;
        public double[] values;
        public List<String> des;

        public PlaceholderItem(String id, String title, String norm, Class<?> view) {
            this.id = id;
            this.title = title;
            this.norm = norm;
            this.view = view;
            this.result = "-";
        }

        public PlaceholderItem(String id, String title, String norm, Class<?> view, double[] values, List<String> des) {
            this.id = id;
            this.title = title;
            this.norm = norm;
            this.view = view;
            this.result = "-";
            this.values = values;
            this.des = des;
        }

        @Override
        public String toString() {
            return title;
        }
    }
}