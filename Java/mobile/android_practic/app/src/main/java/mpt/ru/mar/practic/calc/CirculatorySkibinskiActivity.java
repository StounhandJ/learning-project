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

public class CirculatorySkibinskiActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_circulatory_skibinski);

        setTitle("Циркулярно-респираторный коэффициент Скибински");

        Bundle bundle = getIntent().getExtras();
        int code = bundle.getInt("code");

        Button btn = findViewById(R.id.buttonNext);
        btn.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                View originView = (View) v.getParent();
                String gelText = ((EditText) originView.findViewById(R.id.editTextGEL)).getText().toString();
                String phText = ((EditText) originView.findViewById(R.id.editTextPH)).getText().toString();
                String cssText = ((EditText) originView.findViewById(R.id.editTextCSS)).getText().toString();

                if (gelText.equals("") || phText.equals("") || cssText.equals(""))
                    return;


                Intent returnIntent = new Intent();


                double gel = Integer.parseInt(gelText);
                double ph = Integer.parseInt(phText);
                double css = Integer.parseInt(cssText);

                double result = ((gel / 100) * ph) / css;
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