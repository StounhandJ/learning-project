package mpt.ru.mar.practic.calc;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import mpt.ru.mar.practic.R;
import mpt.ru.mar.practic.ResultActivity;

public class IndexFunctionalActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_index_functional);

        setTitle("Уровень регуляции сердечно-сосудистой системы");

        Bundle bundle = getIntent().getExtras();
        int code = bundle.getInt("code");
        int age = bundle.getInt("age");

        Button btn = findViewById(R.id.buttonNext);
        btn.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                View originView = (View) v.getParent();
                String cssText = ((EditText) originView.findViewById(R.id.editTextCSS)).getText().toString();
                String sadText = ((EditText) originView.findViewById(R.id.editTextSAD)).getText().toString();
                String dadText = ((EditText) originView.findViewById(R.id.editTextDAD)).getText().toString();
                String mtText = ((EditText) originView.findViewById(R.id.editTextMT)).getText().toString();
                String pText = ((EditText) originView.findViewById(R.id.editTextP)).getText().toString();

                if (cssText.equals("") || sadText.equals("") || dadText.equals("") || mtText.equals("") || pText.equals(""))
                    return;


                Intent returnIntent = new Intent();


                double css = Integer.parseInt(cssText);
                double sad = Integer.parseInt(sadText);
                double dad = Integer.parseInt(dadText);
                double mt = Integer.parseInt(mtText);
                double p = Integer.parseInt(pText);

                double result = 0.011 * css + 0.014 * sad + 0.008 * dad + 0.014 * age + 0.009 * mt - 0.009 * p - 0.27;
                returnIntent.putExtra("result", Math.round(result * 100) / 100.0);
                returnIntent.putExtra("code", code);
                setResult(Activity.RESULT_OK, returnIntent);

                Intent intent = new Intent(getApplicationContext(), ResultActivity.class);
                intent.putExtra("result", Math.round(result * 100) / 100.0);

                intent.putExtra("des", getDes(bundle.getStringArray("des"), bundle.getDoubleArray("values"), result));
                startActivityForResult(intent, 0);
            }
        });
    }

    private String getDes(String[] des, double[] values, Double result) {
        int z = 0;
        for (int i = 0; values.length > i; i += 2) {
            if (result > values[i] && result < values[i + 1])
                return des[z];
            z += 1;
        }
        return "-";
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        finish();
    }
}