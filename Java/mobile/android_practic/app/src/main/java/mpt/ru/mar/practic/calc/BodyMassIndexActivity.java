package mpt.ru.mar.practic.calc;


import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import java.util.LinkedList;
import java.util.List;

import mpt.ru.mar.practic.R;
import mpt.ru.mar.practic.ResultActivity;

public class BodyMassIndexActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_body_mass_index);

        setTitle("Индекс массы тела (кг/м2)");

        Bundle bundle = getIntent().getExtras();
        int code = bundle.getInt("code");

        Button btn = findViewById(R.id.buttonNext);
        btn.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                View originView = (View) v.getParent();
                String hText = ((EditText) originView.findViewById(R.id.editTextHeight)).getText().toString();
                String mText = ((EditText) originView.findViewById(R.id.editTextWeight)).getText().toString();

                if (hText.equals("") || mText.equals(""))
                    return;


                Intent returnIntent = new Intent();


                double h = Integer.parseInt(hText) / 100.0;
                int m = Integer.parseInt(mText);

                double result = (double) m / (h * h);
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

    private String getDes(String[] des, double[] values, Double result)
    {
        int z = 0;
        for (int i=0; values.length>i;i+=2)
        {
            if (result>values[i] && result<values[i+1])
                return des[z];
            z+=1;
        }
        return "-";
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        finish();
    }
}